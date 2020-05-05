using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Dtos.Player;
using backend.Models;

namespace backend.Services.PlayerService
{
    public interface IPlayerService
    {
        Task<ServiceResponse<List<GetPlayerDto>>> GetAllPlayers();
        Task<ServiceResponse<GetPlayerDto>> GetPlayerById(int id);
        Task<ServiceResponse<List<GetPlayerDto>>> AddPlayer(AddPlayerDto newPlayer);
        Task<ServiceResponse<List<GetPlayerDto>>> DeleteCharacter(int id);
    }
}