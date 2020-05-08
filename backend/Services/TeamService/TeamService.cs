using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using backend.Data;
using backend.Dtos.Team;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services.TeamService
{
    public class TeamService : ITeamService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public TeamService(IMapper mapper, DataContext context)
        {
            this._context = context;
            this._mapper = mapper;

        }

        public async Task<ServiceResponse<List<GetTeamDto>>> AddTeam(AddTeamDto newTeam)
        {
            ServiceResponse<List<GetTeamDto>> serviceResponse = new ServiceResponse<List<GetTeamDto>>();
            Team team = _mapper.Map<Team>(newTeam);
            
            await _context.Teams.AddAsync(team);
            await _context.SaveChangesAsync();
            serviceResponse.Data = (_context.Teams.Select(p => _mapper.Map<GetTeamDto>(p))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetTeamDto>>> GetAllTeams()
        {
            ServiceResponse<List<GetTeamDto>> serviceResponse = new ServiceResponse<List<GetTeamDto>>();

            List<Team> dbTeams = await _context.Teams.ToListAsync();
            serviceResponse.Data = dbTeams.Select(p => _mapper.Map<GetTeamDto>(p)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetTeamDto>> GetTeamById(int id)
        {
            ServiceResponse<GetTeamDto> serviceResponse = new ServiceResponse<GetTeamDto>();

            Team dbTeam = await _context.Teams.FirstOrDefaultAsync(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetTeamDto>(dbTeam);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetTeamDto>>> DeleteTeam(int id)
        {
            ServiceResponse<List<GetTeamDto>> serviceResponse = new ServiceResponse<List<GetTeamDto>>();
            try
            {
                Team team = await _context.Teams.FirstAsync(c => c.Id == id);
                _context.Teams.Remove(team);
                await _context.SaveChangesAsync();
                
                serviceResponse.Data = (_context.Teams.Select(c => _mapper.Map<GetTeamDto>(c))).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        /*
            --update
            Character character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == updatedCharacter.Id);
            _context.Characters.Update(character);
            await _context.SaveChangesAsync();
        */
    }
}