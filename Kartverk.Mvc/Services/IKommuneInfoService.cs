// Definerer et interface for å hente kommuneinformasjon
using Kartverk.Mvc.API_Models;

namespace Kartverk.Mvc.Services
{
    // Interface for KommuneInfoService
    public interface IKommuneInfoService
    {
        // Metode som henter kommuneinformasjon asynkront basert på geografiske koordinater (y, x)
        // 'y' er breddegraden og 'x' er lengdegraden.
        // Metoden returnerer et Task som resulterer i et KommuneInfo-objekt
        Task<KommuneInfo> GetKommuneInfoAsync(double y, double x);
    }
}