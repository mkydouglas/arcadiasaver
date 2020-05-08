

using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Dtos.Team;
using backend.Models;
using backend.Services.TeamService;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;
        public TeamController(ITeamService teamService)
        {
            this._teamService = teamService;
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _teamService.GetAllTeams());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            return Ok(await _teamService.GetTeamById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddTeam(AddTeamDto newTeam)
        {
            return Ok(await _teamService.AddTeam(newTeam));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ServiceResponse<List<GetTeamDto>> response = await _teamService.DeleteTeam(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}