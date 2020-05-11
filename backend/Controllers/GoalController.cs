using System.Threading.Tasks;
using backend.Dtos.Goal;
using backend.Services.GoalService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class GoalController : ControllerBase
    {
        private readonly IGoalService _service;
        public GoalController(IGoalService service)
        {
            this._service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddGoal(AddGoalDto newGoal)
        {
            return Ok(await _service.AddGoal(newGoal));
        }

        [HttpGet]
        public async Task<IActionResult> GetGoal()
        {
            return Ok(await _service.GetGoal());
        }
    }
}