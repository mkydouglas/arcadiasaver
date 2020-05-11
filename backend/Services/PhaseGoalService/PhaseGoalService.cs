using System;
using System.Threading.Tasks;
using AutoMapper;
using backend.Data;
using backend.Dtos.Phase;
using backend.Dtos.PhaseGoal;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services.PhaseGoalService
{
    public class PhaseGoalService : IPhaseGoalService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public PhaseGoalService(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<ServiceResponse<GetPhaseDto>> AddPhaseGoal(AddPhaseGoalDto newPhaseGoal)
        {
            ServiceResponse<GetPhaseDto> response = new ServiceResponse<GetPhaseDto>();
            try
            {
                Phase phase = await _context.Phases
                    .Include(t => t.PhaseGoals).ThenInclude(tg => tg.Goal)
                    .FirstOrDefaultAsync(c => c.Id == newPhaseGoal.PhaseId);

                if (phase == null)
                {
                    response.Success = false;
                    response.Message = "Phase not found.";
                    return response;
                }
                
                Goal goal = await _context.Goals
                    .FirstOrDefaultAsync(g => g.Id == newPhaseGoal.GoalId);
                if (goal == null)
                {
                    response.Success = false;
                    response.Message = "Goal not found.";
                    return response;
                }
                PhaseGoal phaseGoal = new PhaseGoal
                {
                    Phase = phase,
                    Goal = goal
                };

                await _context.PhaseGoals.AddAsync(phaseGoal);
                await _context.SaveChangesAsync();

                response.Data = _mapper.Map<GetPhaseDto>(phase);
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