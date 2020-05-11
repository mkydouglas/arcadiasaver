using System.Threading.Tasks;
using backend.Dtos.PlayerCampaign;
using backend.Services.PlayerCampaignService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PlayerCampaignController : ControllerBase
    {
        private readonly IPlayerCampaignService _service;
        public PlayerCampaignController(IPlayerCampaignService service)
        {
            this._service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddPlayerCampaign(
            AddPlayerCampaignDto newPc)
        {
            return Ok(await _service.AddPlayerCampaign(newPc));
        }
    }
}