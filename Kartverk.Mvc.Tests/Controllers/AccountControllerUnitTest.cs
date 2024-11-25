namespace Kartverk.Mvc.Tests.Controllers;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Moq;
using Kartverk.Mvc.Models.Feilmelding;

public class AccountControllerTests
{
    private readonly Mock<UserManager<IdentityUser>> _mockUserManager;
    private readonly Mock<SignInManager<IdentityUser>> _mockSignInManager;
    private readonly ApplicationDbContext _context;
    private readonly AccountController _controller;

    public AccountControllerTests()
    {
        // Standard setup code remains the same...
        _mockUserManager = new Mock<UserManager<IdentityUser>>(
            Mock.Of<IUserStore<IdentityUser>>(),
            default, default, default, default, default, default, default, default);


        var mockHttpContextAccessor = new Mock<IHttpContextAccessor>();
        var mockUserClaimsPrincipalFactory = new Mock<IUserClaimsPrincipalFactory<IdentityUser>>();
        var mockIdentityOptions = new Mock<IOptions<IdentityOptions>>();
        var mockLogger = new Mock<ILogger<SignInManager<IdentityUser>>>();
        var mockAuthenticationSchemeProvider = new Mock<IAuthenticationSchemeProvider>();
        var mockUserConfirmation = new Mock<IUserConfirmation<IdentityUser>>();

        _mockSignInManager = new Mock<SignInManager<IdentityUser>>(
                _mockUserManager.Object,
                mockHttpContextAccessor.Object,
                mockUserClaimsPrincipalFactory.Object,
                mockIdentityOptions.Object,
                mockLogger.Object,
                mockAuthenticationSchemeProvider.Object,
                mockUserConfirmation.Object);

        // Set up ApplicationDbContext with an in-memory database
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        _context = new ApplicationDbContext(options);

        // Pass the actual _context instead of a Mock for simplicity
        _controller = new AccountController(_context, _mockUserManager.Object, _mockSignInManager.Object);
    }

    // 1. Test GET Actions Return Correct ViewResult
    [Fact]
    public void LoggInn_GET_ReturnsViewResult()
    {
        // Act
        var result = _controller.LoggInn();

        // Assert
        Assert.IsType<ViewResult>(result);
    }

    [Fact]
    public void Register_GET_ReturnsViewResult()
    {
        // Act
        var result = _controller.Register();

        // Assert
        Assert.IsType<ViewResult>(result);
    }

    // 2. Test Model State Validation
    [Fact]
    public async Task LoggInn_POST_InvalidModelState_ReturnsViewWithModel()
    {
        // Arrange
        _controller.ModelState.AddModelError("", "Test error");
        var model = new LogginnViewModel();

        // Act
        var result = await _controller.LoggInn(model);

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.Equal(model, viewResult.Model);
    }

    [Theory]
    [InlineData("", "password")]  // Empty email
    [InlineData("invalid", "password")]  // Invalid email format
    [InlineData("valid@email.com", "")]  // Empty password
    public async Task Register_POST_InvalidInput_ReturnsViewWithModelErrors(string email, string password)
    {
        // Arrange
        var model = new RegisterViewModel { Email = email, Password = password };

        // Act
        var result = await _controller.Register(model);

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.False(_controller.ModelState.IsValid);
        Assert.Equal(model, viewResult.Model);
    }

    // 5. Test Security Features
    [Fact]
    public Task LoggUt_RequiresAntiForgeryToken()
    {
        var method = typeof(AccountController).GetMethod("LoggUt");
        Assert.NotNull(method); // Ensure method is not null
        var attribute = method!.GetCustomAttributes(typeof(ValidateAntiForgeryTokenAttribute), true);
        Assert.NotEmpty(attribute);
        return Task.CompletedTask;
    }
    
    // 6. Test Error Handling
    [Fact]
    public async Task Register_POST_DuplicateEmail_ReturnsViewWithError()
    {
        // Arrange
        var model = new RegisterViewModel { Email = "existing@test.com", Password = "password" };
        _mockUserManager.Setup(x => x.FindByEmailAsync(model.Email))
            .ReturnsAsync(new IdentityUser());

        // Act
        var result = await _controller.Register(model);

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.Contains(
            _controller.ModelState[string.Empty].Errors,
            error => error.ErrorMessage == "Brukeren eksisterer allerede."
        );
    }

    // 7. Test Database Interactions
    [Fact]
    public void GetUserByEmail_ReturnsCorrectUser()
    {
        // Arrange
        var email = "test@test.com";
        var expectedUser = new IdentityUser { Email = email };
        var users = new List<IdentityUser> { expectedUser }.AsQueryable();

        var mockSet = MockDbSet(users);
        _context.Users.Add(expectedUser);
        _context.SaveChanges();

        // Act
        var result = _controller.GetUserByEmail(email);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(email, result.Email);
    }

    // Helper Methods
    private void SetupSuccessfulLogin(IdentityUser user)
    {
        _mockUserManager.Setup(x => x.FindByEmailAsync(user.Email!)).ReturnsAsync(user);
        _mockSignInManager.Setup(x => x.PasswordSignInAsync(
            user.Email!,
            It.IsAny<string>(),
            false,
            false
        )).ReturnsAsync(Microsoft.AspNetCore.Identity.SignInResult.Success);
    }
    
    private static Mock<DbSet<T>> MockDbSet<T>(IQueryable<T> data) where T : class
    {
        var mockSet = new Mock<DbSet<T>>();
        mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator);
        return mockSet;
    }
}
