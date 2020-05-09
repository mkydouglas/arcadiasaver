using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Dtos.Team;
using backend.Models;

namespace backend.Services.TeamService
{
    public interface ITeamService
    {
        Task<ServiceResponse<List<GetTeamDto>>> GetAllTeams();
        Task<ServiceResponse<GetTeamDto>> GetTeamById(int id);
        Task<ServiceResponse<List<GetTeamDto>>> AddTeam(AddTeamDto newTeam);
        Task<ServiceResponse<List<GetTeamDto>>> DeleteTeam(int id);
        Task<ServiceResponse<GetTeamDto>> UpdateTeam(UpdateTeamDto updateTeam);
    }
}