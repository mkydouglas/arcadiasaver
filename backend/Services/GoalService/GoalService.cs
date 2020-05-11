using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using backend.Data;
using backend.Dtos.Goal;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services.GoalService
{
    public class GoalService : IGoalService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public GoalService(IMapper mapper, DataContext context)
        {
            this._context = context;
            this._mapper = mapper;

        }
        public async Task<ServiceResponse<GetGoalDto>> AddGoal(AddGoalDto newGoal)
        {
            ServiceResponse<GetGoalDto> response = new ServiceResponse<GetGoalDto>();
            
            Goal goal = _mapper.Map<Goal>(newGoal);
            await _context.Goals.AddAsync(goal);
            await _context.SaveChangesAsync();

            response.Data = _mapper.Map<GetGoalDto>(goal);

            return response;
        }

        public async Task<ServiceResponse<List<GetGoalDto>>> GetGoal()
        {
            ServiceResponse<List<GetGoalDto>> response = new ServiceResponse<List<GetGoalDto>>();
            
            List<Goal> goals = await _context.Goals
                .ToListAsync();

            response.Data = goals.Select(p => _mapper.Map<GetGoalDto>(p)).ToList();

            return response;
        }
    }
}