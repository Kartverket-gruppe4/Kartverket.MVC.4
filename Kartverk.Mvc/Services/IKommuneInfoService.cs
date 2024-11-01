using Kartverk.Mvc.API_Models;

namespace Kartverk.Mvc.Services
{
    public interface IKommuneInfoService
    {
        Task<KommuneInfo> GetKommuneInfoAsync(double y, double x);
    }
}