using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using backend.Data;
using backend.Dtos.Team;
using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace backend.Services.TeamService
{
    public class TeamService : ITeamService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor ;
        public TeamService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor  = httpContextAccessor;
            this._context = context;
            this._mapper = mapper;

        }

        public async Task<ServiceResponse<List<GetTeamDto>>> AddTeam(AddTeamDto newTeam)
        {
            ServiceResponse<List<GetTeamDto>> serviceResponse = new ServiceResponse<List<GetTeamDto>>();
            Team team = _mapper.Map<Team>(newTeam);
            team.Player = await _context.Players.FirstOrDefaultAsync(u => u.Id == GetUserId());
            
            await _context.Teams.AddAsync(team);
            await _context.SaveChangesAsync();
            
            serviceResponse.Data = (_context.Teams.Where(t => t.Player.Id == GetUserId()).Select(p => _mapper.Map<GetTeamDto>(p))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetTeamDto>>> GetAllTeams()
        {
            ServiceResponse<List<GetTeamDto>> serviceResponse = new ServiceResponse<List<GetTeamDto>>();

            List<Team> dbTeams = await _context.Teams.Include(t => t.TeamGoals).ThenInclude(tg => tg.Goal).Where(t => t.Player.Id == GetUserId()).ToListAsync();
            serviceResponse.Data = dbTeams.Select(p => _mapper.Map<GetTeamDto>(p)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetTeamDto>> GetTeamById(int id)
        {
            ServiceResponse<GetTeamDto> serviceResponse = new ServiceResponse<GetTeamDto>();

            Team dbTeam = await _context.Teams.FirstOrDefaultAsync(c => c.Id == id && c.Player.Id == GetUserId());
            serviceResponse.Data = _mapper.Map<GetTeamDto>(dbTeam);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetTeamDto>>> DeleteTeam(int id)
        {
            ServiceResponse<List<GetTeamDto>> serviceResponse = new ServiceResponse<List<GetTeamDto>>();
            try
            {
                Team team = await _context.Teams.FirstAsync(c => c.Id == id && c.Player.Id == GetUserId());
                if(team != null){
                    _context.Teams.Remove(team);
                    await _context.SaveChangesAsync();

                    serviceResponse.Data = (_context.Teams.Where(c => c.Player.Id == GetUserId()).Select(c => _mapper.Map<GetTeamDto>(c))).ToList();
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Character not found.";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetTeamDto>> UpdateTeam(UpdateTeamDto updateTeam)
        {
            ServiceResponse<GetTeamDto> serviceResponse = new ServiceResponse<GetTeamDto>();

            try
            {
                Team team = await _context.Teams.Include(c => c.Player).FirstOrDefaultAsync(c => c.Id == updateTeam.Id);
                team.Name = updateTeam.Name;
                _context.Teams.Update(team);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
    }
}