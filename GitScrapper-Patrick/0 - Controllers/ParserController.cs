using GitScrapper_Patrick._1_Services;
using GitScrapper_Patrick._3_Shared;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace GitScrapper_Patrick.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParserController : ControllerBase
    {
        private readonly IScrapperService _scrapperService;
        public ParserController(IScrapperService scrapperService)
        {
            _scrapperService = scrapperService;
        }

        /// Return all files of a given repository, grouped by extension with total number lines and size.
        /// Sample request:
        ///
        ///     POST 
        ///     "https://github.com/PatrickTB/GitScrapper"
        /// </remarks>
        /// <param name="baseUrl">Github Repository Url.</param>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpPost("read-data-repository")]
        public async Task<IActionResult> PaserUrl([FromBody] Request request)
        {
            if (string.IsNullOrEmpty(request.Url))
                return base.BadRequest(_3_Shared.Response.Empty);

            var response = await Task.FromResult(_scrapperService.GetGithubFilesGroupedByExtension(request.Url));
            return Ok(JsonConvert.SerializeObject(response));
        }
    }
}
