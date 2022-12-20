using Microsoft.AspNetCore.Mvc;
using MoviesApp.Service.Common;

namespace MoviewApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TMDBController : ControllerBase
    {
        public TMDBController(ITMDBService service)
        {
            TMDBService = service;
        }

        protected ITMDBService TMDBService { get; private set; }

        [HttpGet("refresh-data")]
        public async Task<bool> RefreshDataAsync()
        {
            await TMDBService.GetAPIData();
            return true;
        }
    }
}