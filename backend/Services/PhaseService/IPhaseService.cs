using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Dtos.Phase;
using backend.Models;

namespace backend.Services.PhaseService
{
    public interface IPhaseService
    {
        Task<ServiceResponse<GetPhaseDto>> AddPhase(AddPhaseDto newPhase, string campaignId);
        Task<ServiceResponse<List<GetPhaseDto>>> GetPhases(string campaignId);
    }
}