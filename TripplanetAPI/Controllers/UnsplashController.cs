using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TripplanetAPI.Models;
using TripplanetAPI.Services;

namespace TripplanetAPI.Controllers
{
    [ApiController]
    [Route("Location")]
    public class UnsplashController : ControllerBase
    {
        private readonly IUnsplashService _unsplashService;
        public UnsplashController(IUnsplashService unsplashService)
        {
            _unsplashService = unsplashService;
        }
        [HttpGet]
        public async Task<List<Location>?> GetData()
        {
            return await _unsplashService.GetData();
        }

        [HttpPost]
        public async Task<IActionResult> PostUnsplashData()
        {
            //var unsplashData = await _unsplashService.PostUnsplashData();
            return Ok();
        }
    }
}
