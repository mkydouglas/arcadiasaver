using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    [Route("player")]
    public class PlayerController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Player>> SignUp(
            [FromServices]DataContext context
        )
        {
            try
            {
                Player player = new Player();
                string aux = Guid.NewGuid().ToString();
                player.PlayerId = aux.Substring(0, 7);

                context.Player.Add(player);
                await context.SaveChangesAsync();
                return Ok(player);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível criar o jogador" });
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<string>> LogIn(
            [FromBody]Player player,
            [FromServices]DataContext context
        )
        {
            var playerReturn = await context.Player.AsNoTracking().FirstOrDefaultAsync(x => x.PlayerId.Equals(player.PlayerId));
            if (playerReturn == null)
                return NotFound(new { message = "Player não encontrado" });

            return Ok();
        }
    }
}