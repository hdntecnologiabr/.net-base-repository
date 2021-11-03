using Hdn.Core.Architecture.Application.Dtos.Movie;
using Hdn.Core.Architecture.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Hdn.Core.Architecture.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService movieService;
        public MovieController(IMovieService movieService) =>
            this.movieService = movieService ?? throw new ArgumentNullException(nameof(movieService));

        [HttpGet]
        public async Task<ActionResult> GetAllAsync() =>
            Ok(await movieService.GetAllAsync());

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetAsync(Guid id) =>
            Ok(await movieService.GetAsync(id));

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] MoviePostRequestDto content) =>
            CreatedAtAction("Get", await movieService.PostAsync(content));

        [HttpPut]
        public async Task<ActionResult> PutAsync([FromBody] MoviePutRequestDto content)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await movieService.PutAsync(content);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(Guid id) =>
            Ok(await movieService.DeleteAsync(id));
    }
}
