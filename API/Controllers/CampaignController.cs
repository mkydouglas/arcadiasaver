using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("campaign")]
    public class CampaignController : ControllerBase
    {
        //TODO:atualizar busca pelo id do time em jogo e não pelo id do player
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<Campaign>> GetCampaignId(
            [FromHeader]string playerId,
            [FromServices]DataContext context)
        {
            Campaign campaignReturn = await context.Campaigns.AsNoTracking().FirstOrDefaultAsync(x => x.Player.Equals(playerId));
            return campaignReturn;
        }

        [HttpGet]
        [Route("getcampaigns")]
        public List<string> GetCampaigns()
        {
            List<string> campaigns = Campaign.PreencheLista();
            return campaigns;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Campaign>> NewGame(
            [FromHeader]string playerId,
            [FromBody]Campaign campaign,
            [FromServices]DataContext context)
        {
            try
            {
                if (campaign.NumberOfPlayers > 4)
                    return BadRequest();

                campaign.CampaignId = Guid.NewGuid().ToString().Substring(0,7);
                campaign.Player = playerId;
                campaign.PlayersQuantity = 1;

                context.Campaigns.Add(campaign);
                await context.SaveChangesAsync();
                return Ok(campaign);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível criar a campanha" });
            }
            
        }

        [HttpPost]
        [Route("getin")]
        public async Task<ActionResult<Campaign>> GetIn(
            [FromHeader]string playerId,
            [FromBody]Campaign campaign,
            [FromServices]DataContext context)
        {
            try
            {
                Campaign campaignReturn = await context.Campaigns.AsNoTracking().FirstOrDefaultAsync(x => x.CampaignId.Equals(campaign.CampaignId));
                if (campaignReturn == null)
                    return NotFound();

                campaignReturn.CampaignId = campaign.CampaignId;

                if (campaignReturn.PlayersQuantity < campaignReturn.NumberOfPlayers)
                {
                    if(campaignReturn.PlayersQuantity == 1)
                        campaignReturn.Player2 = playerId;
                    else if (campaignReturn.PlayersQuantity == 2)
                        campaignReturn.Player3 = playerId;
                    else if (campaignReturn.PlayersQuantity == 3)
                        campaignReturn.Player4 = playerId;

                    campaignReturn.PlayersQuantity++;
                }
                else
                    return BadRequest(new { message = "Número de jogadores excedido" });

                context.Entry(campaignReturn).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(campaignReturn);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível entrar na campanha" });
            }

        }
    }
}