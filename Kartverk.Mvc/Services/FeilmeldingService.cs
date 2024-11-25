using System.Data;
using Dapper;
using Kartverk.Mvc.Models.Feilmelding;

namespace Kartverk.Mvc.Services
{
    public class FeilmeldingService
    {
        private readonly IDbConnection _dbConnection;

        // Konsturktør som initialiserer tjenesten med en database-tilkobling.
        public FeilmeldingService(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        // Legger til en ny feilmelding i databasen.
        public void AddFeilmelding(string email, string beskrivelse, string dato, string geojson, string kommuneinfo, string status, string userId)
        {
            string query = @"INSERT INTO feilmeldinger (Email, Beskrivelse, Dato, GeoJson, Kategori, Kommuneinfo, Status, UserId)
                             VALUES (@Email, @Beskrivelse, @Dato, @GeoJson, @Kategori, @Kommuneinfo, @Status, @UserId)";
            _dbConnection.Execute(query, new { Email = email, Beskrivelse = beskrivelse, Dato = dato, GeoJson = geojson, KommuneInfo = kommuneinfo, Status = status, UserId = userId });
        }

        // Henter alle feilmeldinger for en spesifikk bruker basert på UserId.
        public IEnumerable<FeilmeldingViewModel> GetAllFeilmeldinger(string userId)
        {
            string query = @"SELECT * FROM feilmeldinger WHERE UserId = @UserId";
            return _dbConnection.Query<FeilmeldingViewModel>(query, new { UserId = userId });
        }

        // Henter en spesifikk feilmelding ved dens Id for en spesifikk bruker.
        public FeilmeldingViewModel? GetFeilmeldingById(int id, string userId)
        {
            string query = "SELECT * FROM feilmeldinger WHERE Id = @Id AND UserId = @UserId";
            return _dbConnection.QuerySingleOrDefault<FeilmeldingViewModel>(query, new { Id = id, UserId = userId });
        }

        // Oppdaterer en eksisterende feilmelding i databasen.
        public void UpdateFeilmelding(string email, string beskrivelse, string dato, string geojsonData, string kommuneinfo, string status, string userId)
        {
            string query = @"UPDATE feilmeldinger
                             SET Email = @Email, Beskrivelse = @Beskrivelse, Dato = @Dato, GeoJson = @GeoJson, KommuneInfo = @KommuneInfo, Status = @Status
                             WHERE Id = @Id AND UserId = @UserId";
            Console.WriteLine(query);
            _dbConnection.Execute(query, new { Email = email, Beskrivelse = beskrivelse, Dato = dato, GeoJson = geojsonData, KommuneInfo = kommuneinfo, Stauts = status, UserId = userId });
        }

        // Sletter en spesifikk feilmelding basert op Id og UserId.
        public void DeleteFeilmelding(int id, string userId)
        {
            string query = "DELETE FROM feilmeldinger WHERE Id = @Id AND UserId = @UserId";
            _dbConnection.Execute(query, new { Id = id, UserId = userId });
        }
    }
}
