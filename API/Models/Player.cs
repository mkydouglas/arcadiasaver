using API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        public string PlayerId { get; set; }
        public List<PlayerCampaign> PlayerCampaigns { get; set; }
        public List<Team> Teams { get; set; }

        /*public static async Task<ActionResult<Player>> GetPlayer(DataContext context, string id)
        {
            Player player = await context.Player.AsNoTracking().FirstOrDefaultAsync(p => p.PlayerId.Equals(id));
            return player;
        }*/
    }
}
