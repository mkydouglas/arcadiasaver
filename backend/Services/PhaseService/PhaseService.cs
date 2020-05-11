using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using backend.Data;
using backend.Dtos.Phase;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services.PhaseService
{
    public class PhaseService : IPhaseService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public PhaseService(DataContext context, IMapper mapper)
        {
            this._mapper = mapper;
            this._context = context;

        }
        public async Task<ServiceResponse<GetPhaseDto>> AddPhase(AddPhaseDto newPhase, string campaignId)
        {
            ServiceResponse<GetPhaseDto> response = new ServiceResponse<GetPhaseDto>();
            Campaign campaign = await _context.Campaigns
                .Where(c => c.CampaignId.Equals(campaignId))
                .FirstOrDefaultAsync();
            if (campaign == null)
            {
                response.Success = false;
                response.Message = "Campaign not found.";
                return response;
            }

            Phase phase = _mapper.Map<Phase>(newPhase);
            phase.Campaign = campaign;

            await _context.Phases.AddAsync(phase);
            await _context.SaveChangesAsync();

            return response;
        }

        public async Task<ServiceResponse<List<GetPhaseDto>>> GetPhases(string campaignId)
        {
            ServiceResponse<List<GetPhaseDto>> response = new ServiceResponse<List<GetPhaseDto>>();
            Campaign campaign = await _context.Campaigns
                .Where(c => c.CampaignId.Equals(campaignId))
                .FirstOrDefaultAsync();
            if (campaign == null)
            {
                response.Success = false;
                response.Message = "Campaign not found.";
                return response;
            }

            List<Phase> phases = await _context.Phases
                .Where(p => p.Campaign.Id == campaign.Id)
                .ToListAsync();

            response.Data = phases.Select(p => _mapper.Map<GetPhaseDto>(p)).ToList();

            return response;
        }
    }
}