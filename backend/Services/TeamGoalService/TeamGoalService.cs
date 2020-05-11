using System;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using backend.Data;
using backend.Dtos.Team;
using backend.Dtos.TeamGoal;
using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace backend.Services.TeamGoalService
{
    public class TeamGoalService : ITeamGoalService
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public TeamGoalService(DataContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }
        public async Task<ServiceResponse<GetTeamDto>> AddTeamGoal(AddTeamGoalDto newTeamGoal)
        {
            ServiceResponse<GetTeamDto> response = new ServiceResponse<GetTeamDto>();
            try
            {
                Team team = await _context.Teams
                    .Include(t => t.TeamGoals).ThenInclude(tg => tg.Goal)
                    .FirstOrDefaultAsync(c => c.Id == newTeamGoal.TeamId &&
                    c.Player.Id == int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)));

                if (team == null)
                {
                    response.Success = false;
                    response.Message = "Team not found.";
                    return response;
                }
                
                Goal goal = await _context.Goals
                    .FirstOrDefaultAsync(g => g.Id == newTeamGoal.GoalId);
                if (goal == null)
                {
                    response.Success = false;
                    response.Message = "Goal not found.";
                    return response;
                }
                TeamGoal teamGoal = new TeamGoal
                {
                    Team = team,
                    Goal = goal
                };

                await _context.TeamGoals.AddAsync(teamGoal);
                await _context.SaveChangesAsync();

                response.Data = _mapper.Map<GetTeamDto>(team);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}