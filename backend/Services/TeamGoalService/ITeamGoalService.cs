using System.Threading.Tasks;
using backend.Dtos.Team;
using backend.Dtos.TeamGoal;
using backend.Models;

namespace backend.Services.TeamGoalService
{
    public interface ITeamGoalService
    {
        Task<ServiceResponse<GetTeamDto>> AddTeamGoal(AddTeamGoalDto newTeamGoal);
    }
}