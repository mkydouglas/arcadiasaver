using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos.Player;
using backend.Models;
using backend.Services.PlayerService;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        public PlayerController(IPlayerService playerService)
        {
            this._playerService = playerService;
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _playerService.GetAllPlayers());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            return Ok(_playerService.GetPlayerById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddPlayer(AddPlayerDto newPlayer)
        {
            return Ok(_playerService.AddPlayer(newPlayer));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ServiceResponse<List<GetPlayerDto>> response = await _playerService.DeleteCharacter(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}