using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("forum/[controller]")]
    public class SeederController : ControllerBase
    {
        private readonly ISeederService _seederService;

        public SeederController(ISeederService seederService)
        {
            _seederService = seederService;
        }

        [HttpPost("populate")]
        public IActionResult Populate()
        {
            _seederService.Populate();
            return Ok();
        }

        [HttpDelete("drop")]
        public IActionResult Delete()
        {
            _seederService.Clean();
            return Ok();
        }

    }
}
