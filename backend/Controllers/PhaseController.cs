using System.Threading.Tasks;
using backend.Dtos.Phase;
using backend.Services.PhaseService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class PhaseController : ControllerBase
    {
        private readonly IPhaseService _service;
        public PhaseController(IPhaseService service)
        {
            this._service = service;
        }

        public async Task<IActionResult> AddPhase(
            [FromHeader] string campaignId,
            AddPhaseDto newPhase)
        {
            return Ok(await _service.AddPhase(newPhase, campaignId));
        }

        [HttpGet]
        public async Task<IActionResult> GetPhases([FromHeader] string campaignId){
            return Ok(await _service.GetPhases(campaignId));
        }
    }
}