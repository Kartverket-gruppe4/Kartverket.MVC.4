using Kartverk.Mvc.API_Models;

// Interface for å hente kommuneinformasjon.
namespace Kartverk.Mvc.Services
{
    // Interface for KommuneInfoService
    public interface IKommuneInfoService
    {
        // Henter kommuneinfo asynkront basert på koordinater (y, x).
        Task<KommuneInfo> GetKommuneInfoAsync(double y, double x);
    }
}