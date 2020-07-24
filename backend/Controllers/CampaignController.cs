using System;
using System.Threading.Tasks;
using backend.Dtos.Campaign;
using backend.Services.CampaignService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class CampaignController : ControllerBase
    {
        private readonly ICampaignService _service;
        public CampaignController(ICampaignService service)
        {
            this._service = service;

        }

        [HttpPost()]
        public async Task<IActionResult> AddCampaign(AddCampaignDto newCampaign, [FromQuery]int playerId)
        {
            return Ok(await _service.AddCampaign(newCampaign, playerId));
        }

        [HttpGet()]
        public async Task<IActionResult> GetCampaign([FromQuery]string campaignId)
        {
            return Ok(await _service.GetCampaign(campaignId));
        }
    }
}