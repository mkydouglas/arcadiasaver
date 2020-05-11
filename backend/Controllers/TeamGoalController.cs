using System.Threading.Tasks;
using backend.Dtos.TeamGoal;
using backend.Services.TeamGoalService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TeamGoalController : ControllerBase
    {
        private readonly ITeamGoalService _teamGoal;
        public TeamGoalController(ITeamGoalService teamGoal)
        {
            this._teamGoal = teamGoal;

        }

        [HttpPost]
        public async Task<IActionResult> AddTeamGoal(AddTeamGoalDto newTeamGoal){
            return Ok(await _teamGoal.AddTeamGoal(newTeamGoal));
        }
    }
}