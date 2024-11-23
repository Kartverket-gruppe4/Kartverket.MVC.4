using Kartverk.Mvc.Services;
using Kartverk.Mvc.API_Models;
using Microsoft.EntityFrameworkCore;
using Kartverk.Mvc.Models.Feilmelding;
using Microsoft.AspNetCore.Identity;
using MySqlConnector;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Binder API-innstillingene fra appsettings.json
builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection("ApiSettings"));

// Registrer tjenester og deres grensesnitt
builder.Services.AddHttpClient<IKommuneInfoService, KommuneInfoService>();

// legger til identity services
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

// konfigurer autentikasjon
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/LogInn/";
    options.AccessDeniedPath = "/Account/AccessDenied/";
    options.Cookie.Name = "YourAppCookie";
});

// registrer IDbConnection for Dapper
builder.Services.AddTransient<IDbConnection>((sp) =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();
    var connectionString = configuration.GetConnectionString("DefaultConnection");
    return new MySqlConnection(connectionString);
});

// registrer feilmeldingsservice
builder.Services.AddScoped<FeilmeldingService>();

// Legger til session-tjenester for å støtte sesjonshåndtering
builder.Services.AddDistributedMemoryCache(); // Kreves for at sesjonsstatusen skal fungere
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Setter sesjonens timeout (valgfritt)
    options.Cookie.HttpOnly = true; // Sikrer at sesjons-cookie kun er tilgjengelig via HTTP
    options.Cookie.IsEssential = true; // Gjør at cookien er essensiell for appen
});

builder.Services.AddControllersWithViews(); // Legger til støtte for MVC-kontrollere og visninger

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection"); 
Console.WriteLine("ConnectionString: " + connectionString); // Skriver ut til konsollen for debugging

// Konfigurerer Entity Framework (EF) med MariaDB som database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, 
    new MySqlServerVersion(new Version(10, 5, 9)))  // Versjonen av MariaDB som skal brukes
        .LogTo(Console.WriteLine, LogLevel.Information));  // Logger SQL-spørringer for debugging

builder.Services.AddControllersWithViews();  // Legger til MVC-støtte (som en ekstra sikkerhet)

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", 
        builder =>
        {
            // Angir hvilke opprinnelser som er tillatt for CORS
            builder.WithOrigins("https://unpkg.com")  // Eksempel på tillatt opprinnelse
                .AllowAnyHeader()  // Tillater alle headers
                .AllowAnyMethod(); // Tillater alle HTTP-metoder
        });
});

var app = builder.Build(); // Bygger applikasjonen

// Kjør migrasjoner for EF ved applikasjonens oppstart
using (var scope = app.Services.CreateScope())
{
    var errorCount = 0;

    ApplyDatabaseMigrations();

    void ApplyDatabaseMigrations() // tåler at databasen starter tregt

    {
        try
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            dbContext.Database.Migrate(); // Utfører migrasjoner på databasen
        }
        catch
        {
            errorCount++;
            Console.WriteLine("Feil ved migrering av databasen. Forsøk" + errorCount);
            if (errorCount < 5)
            {
                Thread.Sleep(2000); // Venter 2 sekunder før nytt forsøk

                ApplyDatabaseMigrations();
            }
            else
            {
                Console.WriteLine($"Kunne ikke migrere databasen etter {errorCount} forsøk. Avslutter applikasjonen.");
                throw;
            }
        }
    }
}

// Opprett roller og admin-bruker ved oppstart
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = services.GetRequiredService<UserManager<IdentityUser>>();

    string[] roles = { "Administrator", "User" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }

    var adminEmail = "admin@mail.com";
    var adminUser = await userManager.FindByEmailAsync(adminEmail);
    if (adminUser == null)
    {
        adminUser = new IdentityUser { UserName = adminEmail, Email = adminEmail };
        await userManager.CreateAsync(adminUser, "admin123"); // Adjust password as needed
        await userManager.AddToRoleAsync(adminUser, "Administrator");
    }
}


// Konfigurerer HTTP-request pipeline (håndtering av forespørsler)
if (!app.Environment.IsDevelopment())  // Hvis applikasjonen ikke er i utviklingsmodus
{
    app.UseExceptionHandler("/Home/Error");  // Bruker en global feilhåndteringsside
    // Standard HSTS-verdi er 30 dager. Endre dette i produksjonsmiljøet hvis nødvendig
    app.UseHsts();  // Aktivere HSTS (HTTP Strict Transport Security) for ekstra sikkerhet
}

app.UseHttpsRedirection(); // Tvinger HTTPS-forbindelse
app.UseStaticFiles(); // Gjør statiske filer (som bilder, CSS, JS) tilgjengelige

app.UseRouting();  // Setter opp ruter for kontrollere
// Bruk CORS-policyen definert tidligere
app.UseCors("AllowSpecificOrigins");

app.UseAuthentication();
app.UseAuthorization();  // Aktiverer autorisasjon (f.eks. for tilgangskontroll)

// Kartlegger den grunnleggende ruten til MVC (standard controller og action)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Mapper kontrollerne for API
app.MapControllers(); 

app.Run();  // Kjører applikasjonen
