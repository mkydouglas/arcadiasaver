using System.Threading.Tasks;
using backend.Dtos.PhaseGoal;
using backend.Services.PhaseGoalService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PhaseGoalController : ControllerBase
    {
        private readonly IPhaseGoalService _service;
        public PhaseGoalController(IPhaseGoalService service)
        {
            this._service = service;

        }

        [HttpPost]
        public async Task<IActionResult> AddPhaseGoal(AddPhaseGoalDto newPhaseGoal)
        {
            return Ok(await _service.AddPhaseGoal(newPhaseGoal));
        }
    }
}