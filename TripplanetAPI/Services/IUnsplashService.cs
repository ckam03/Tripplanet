using TripplanetAPI.Models;

namespace TripplanetAPI.Services
{
    public interface IUnsplashService
    {
        Task<List<Location>?> GetData();
        Task<List<Location>?> PostUnsplashData();
    }
}
