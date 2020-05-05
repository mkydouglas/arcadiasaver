using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using backend.Data;
using backend.Dtos.Player;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services.PlayerService
{
    public class PlayerService : IPlayerService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public PlayerService(IMapper mapper, DataContext context)
        {
            this._context = context;
            this._mapper = mapper;

        }

        private static List<Player> players = new List<Player> {
            new Player(),
            new Player { Id = 1, Login = "Sam"}
        };

        public async Task<ServiceResponse<List<GetPlayerDto>>> AddPlayer(AddPlayerDto newPlayer)
        {
            ServiceResponse<List<GetPlayerDto>> serviceResponse = new ServiceResponse<List<GetPlayerDto>>();

            Player player = _mapper.Map<Player>(newPlayer);
            player.Id = players.Max(c => c.Id) + 1;
            players.Add(_mapper.Map<Player>(player));
            serviceResponse.Data = (players.Select(p => _mapper.Map<GetPlayerDto>(p))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetPlayerDto>>> GetAllPlayers()
        {
            ServiceResponse<List<GetPlayerDto>> serviceResponse = new ServiceResponse<List<GetPlayerDto>>();

            List<Player> dbPlayers = await _context.Players.ToListAsync();
            serviceResponse.Data = dbPlayers.Select(p => _mapper.Map<GetPlayerDto>(p)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetPlayerDto>> GetPlayerById(int id)
        {
            ServiceResponse<GetPlayerDto> serviceResponse = new ServiceResponse<GetPlayerDto>();

            Player dbPlayer = await _context.Players.FirstOrDefaultAsync(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetPlayerDto>(dbPlayer);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetPlayerDto>>> DeleteCharacter(int id)
        {
            ServiceResponse<List<GetPlayerDto>> serviceResponse = new ServiceResponse<List<GetPlayerDto>>();
            try
            {
                Player player = players.First(c => c.Id == id);
                players.Remove(player);

                serviceResponse.Data = (players.Select(c => _mapper.Map<GetPlayerDto>(c))).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}