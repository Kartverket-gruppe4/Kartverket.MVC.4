using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Data;
using Dapper;
using Kartverk.Mvc.Models.Feilmelding;

namespace Kartverk.Mvc.Services
{
    public class FeilmeldingService
    {
        private readonly IDbConnection _dbConnection;

        public FeilmeldingService(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        //  Setter inn en ny record i feilmeldings tabellen
        public void AddFeilmelding(string email, string beskrivelse, string dato, string geojson, string kommuneinfo, string status, string userId)
        {
            string query = @"INSERT INTO feilmeldinger (Email, Beskrivelse, Dato, GeoJson, Kategori, Kommuneinfo, Status, UserId)
                             VALUES (@Email, @Beskrivelse, @Dato, @GeoJson, @Kategori, @Kommuneinfo, @Status, @UserId)";
            _dbConnection.Execute(query, new { Email = email, Beskrivelse = beskrivelse, Dato = dato, GeoJson = geojson, KommuneInfo = kommuneinfo, Status = status, UserId = userId });
        }

        // Henter feilmeldings tabellen til en spesifikk bruker
        public IEnumerable<FeilmeldingViewModel> GetAllFeilmeldinger(string userId)
        {
            string query = @"SELECT * FROM feilmeldinger WHERE UserId = @UserId";
            return _dbConnection.Query<FeilmeldingViewModel>(query, new { UserId = userId });
        }

        // Henter en enkel feilmelding ved dens unike id for en spesifikk bruker
        public FeilmeldingViewModel GetFeilmeldingById(int id, string userId)
        {
            string query = "SELECT * FROM feilmeldinger WHERE Id = @Id AND UserId = @UserId";
            return _dbConnection.QuerySingleOrDefault<FeilmeldingViewModel>(query, new { Id = id, UserId = userId });
        }

        // Oppdaterer en eksisterende feilmelding record i databasen basert på Id og UserId
        public void UpdateFeilmelding(string email, string beskrivelse, string dato, string geojsonData, string kommuneinfo, string status, string userId)
        {
            string query = @"UPDATE feilmeldinger
                             SET Email = @Email, Beskrivelse = @Beskrivelse, Dato = @Dato, GeoJson = @GeoJson, KommuneInfo = @KommuneInfo, Status = @Status
                             WHERE Id = @Id AND UserId = @UserId";
            Console.WriteLine(query);
            _dbConnection.Execute(query, new { Email = email, Beskrivelse = beskrivelse, Dato = dato, GeoJson = geojsonData, KommuneInfo = kommuneinfo, Stauts = status, UserId = userId });
        }

        // Sletter en eksisterende feilmelding record basert på Id og UserId
        public void DeleteFeilmelding(int id, string userId)
        {
            string query = "DELETE FROM feilmeldinger WHERE Id = @Id AND UserId = @UserId";
            _dbConnection.Execute(query, new { Id = id, UserId = userId });
        }
    }
}
