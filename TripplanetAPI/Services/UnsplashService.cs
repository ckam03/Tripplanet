using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using TripplanetAPI.Data;
using TripplanetAPI.Models;

namespace TripplanetAPI.Services
{
    public class UnsplashService : IUnsplashService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly ApplicationDbContext _dbContext;
        public UnsplashService(HttpClient httpClient, IConfiguration configuration, ApplicationDbContext dbContext)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://api.unsplash.com");
            _apiKey = configuration["Unsplash:ServiceApiKey"];
            _dbContext = dbContext;
        }

        public async Task<List<Location>?> GetData()
        {
            var data = await _dbContext.Location
                .Include(x => x.urls)
                .Include(y => y.location)
                .Include(z => z.location.position)
                .ToListAsync();
            return data;
        }
        public async Task<List<Location>?> PostUnsplashData()
        {
            var request = await _httpClient.GetAsync($"/photos/random?client_id={_apiKey}&count=11&collections=lPypVgHxfhg");
            request.EnsureSuccessStatusCode();
            var response = await request.Content.ReadAsStreamAsync();
            var result = await JsonSerializer.DeserializeAsync<List<Location>>(response);
            if (result is not null)
            {
                _dbContext.Location.AddRange(result);
            }
            _dbContext.SaveChanges();
            return result;
        }
    }
}
