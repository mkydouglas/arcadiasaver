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
    [Route("home")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<Home>> GetData([FromBody]Campaign campaign, [FromServices]DataContext context)
        {
            Home home = new Home();
            //List<Team> teams = new List<Team>();
            //List<string> fases;
            //List<string> players = campaign.BuscaPlayers();

            try
            {
                if (campaign.Name.Equals("arcadia quest"))
                {
                    home.Fases = FasesFactory.CreateFases(FasesOptions.ARCADIAQUEST);
                    Console.WriteLine(home.Fases);
                }

                Player player = await context.Player.AsNoTracking().FirstOrDefaultAsync(p => p.PlayerId.Equals(campaign.Player));
                Player player2 = await context.Player.AsNoTracking().FirstOrDefaultAsync(p => p.PlayerId.Equals(campaign.Player2));
                Player player3 = await context.Player.AsNoTracking().FirstOrDefaultAsync(p => p.PlayerId.Equals(campaign.Player3));
                Player player4 = await context.Player.AsNoTracking().FirstOrDefaultAsync(p => p.PlayerId.Equals(campaign.Player4));

                if (player != null)
                {
                    Team team = await context.Teams.AsNoTracking().FirstOrDefaultAsync(t => t.Id == player.Id);
                    home.Teams.Add(team);
                }

                if (player2 != null)
                {
                    Team team = await context.Teams.AsNoTracking().FirstOrDefaultAsync(t => t.Id == player.Id);
                    home.Teams.Add(team);
                }

                if (player3 != null)
                {
                    Team team = await context.Teams.AsNoTracking().FirstOrDefaultAsync(t => t.Id == player.Id);
                    home.Teams.Add(team);
                }

                if (player4 != null)
                {
                    Team team = await context.Teams.AsNoTracking().FirstOrDefaultAsync(t => t.Id == player.Id);
                    home.Teams.Add(team);
                }

                return Ok(home);
            }
            catch (Exception)
            {

                throw;
            }           
            
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Fase>> PostData(
            /*[FromBody]HomePost homePost,*/
            [FromServices]DataContext context)
        {
            try
            {
                /*Fase fase = new Fase();
                Campaign campaign = await context.Campaigns.AsNoTracking().FirstOrDefaultAsync(c => c.CampaignId.Equals(homePost.CampaignId));
                fase.CampaignId = campaign.Id;
                fase.Name = homePost.Fase;

                //fase.FaseGoals.ForEach(f => f.)

                context.Fases.Add(fase);
                var a = await context.SaveChangesAsync();

               

                

                context.Goals.Add(homePost.Winner);
                await context.SaveChangesAsync();
                context.Goals.Add(homePost.LeastDeaths);
                await context.SaveChangesAsync();
                context.Goals.Add(homePost.MostCoin);
                await context.SaveChangesAsync();
                context.Goals.Add(homePost.WonReward);
                await context.SaveChangesAsync();
                context.Goals.Add(homePost.WonTitle);
                await context.SaveChangesAsync();*/


                var goal = new Goal();
                goal.Name = "Coin";

                var fase = new Fase();
                fase.CampaignId = 3;
                fase.Name = "novo teste";

                // I create two Library2Book which I need them 
                // To map between the books and the library
                var fg1 = new FaseGoal();

                // Mapping the first book to the library.
                // Changed b2lib2.Library to b2lib1.Library
                

                context.Fases.Add(fase);
                context.Goals.Add(goal);

                /*await context.SaveChangesAsync();
                Fase fasfe = await context.Fases.OrderBy(f => f.Id).LastOrDefaultAsync();
                Goal g = await context.Goals.OrderBy(f => f.Id).LastOrDefaultAsync();*/

                //fg1.Goal = goal;
                //fg1.Fase = fase;
                //fasfe.FaseGoals = new List<FaseGoal>();
                fase.FaseGoals.Add(fg1);



                context.Entry(fase).State = EntityState.Modified;
                await context.SaveChangesAsync();

                return Ok(fase);
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
