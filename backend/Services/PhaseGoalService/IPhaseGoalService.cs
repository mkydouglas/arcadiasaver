using System.Threading.Tasks;
using backend.Dtos.Phase;
using backend.Dtos.PhaseGoal;
using backend.Models;

namespace backend.Services.PhaseGoalService
{
    public interface IPhaseGoalService
    {
        Task<ServiceResponse<GetPhaseDto>> AddPhaseGoal(AddPhaseGoalDto newTeamGoal);
    }
}