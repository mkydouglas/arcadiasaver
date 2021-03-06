using System.Threading.Tasks;
using backend.Dtos.Hero;
using backend.Services.HeroService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class HeroController : ControllerBase
    {
        private readonly IHeroService _service;
        public HeroController(IHeroService service)
        {
            this._service = service;
        }

        [HttpPost("{teamId}")]
        public async Task<IActionResult> AddHero(
            AddHeroDto newHero, int teamId)
        {
            return Ok(await _service.AddHero(newHero, teamId));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHeros([FromHeader] int teamId)
        {
            return Ok(await _service.GetAllHeros(teamId));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateHero(
            [FromHeader] int teamId,
            UpdateHero updateHero)
        {
            return Ok(await _service.UpdateHero(updateHero, teamId));
        }
    }
}