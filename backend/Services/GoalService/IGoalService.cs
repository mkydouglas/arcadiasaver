using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Dtos.Goal;
using backend.Models;

namespace backend.Services.GoalService
{
    public interface IGoalService
    {
        Task<ServiceResponse<GetGoalDto>> AddGoal(AddGoalDto newGoal);
        Task<ServiceResponse<List<GetGoalDto>>> GetGoal();
    }
}