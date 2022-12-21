using Microsoft.AspNetCore.Mvc;
using MoviesApp.Model.Common;
using MoviesApp.Service.Common;

namespace MoviewApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        public MoviesController(ILogger<MoviesController> logger, IMovieService service)
        {
            Logger = logger;
            MovieService = service;
        }

        #region Properties

        protected IMovieService MovieService { get; private set; }

        protected ILogger Logger { get; private set; }

        #endregion Properties

        [HttpGet("movies")]
        public async Task<IActionResult> GetMoviesAsync([FromQuery] string? searchTerm = "", [FromQuery] int pageNumber = 1)
        {
            IMovieResult movies = await MovieService.GetAll(searchTerm, pageNumber);
            return Ok(movies);
        }
    }
}
