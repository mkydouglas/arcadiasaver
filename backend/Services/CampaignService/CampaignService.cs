using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using backend.Data;
using backend.Dtos.Campaign;
using backend.Dtos.PlayerCampaign;
using backend.Models;
using backend.Services.PlayerCampaignService;
using Microsoft.EntityFrameworkCore;

namespace backend.Services.CampaignService
{
    public class CampaignService : ICampaignService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IPlayerCampaignService _service;
        public CampaignService(DataContext context, IMapper mapper, IPlayerCampaignService service)
        {
            this._service = service;
            this._mapper = mapper;
            this._context = context;

        }
        public async Task<ServiceResponse<GetCampaignDto>> AddCampaign(AddCampaignDto newCampaign, int playerId)
        {
            ServiceResponse<GetCampaignDto> response = new ServiceResponse<GetCampaignDto>();
            Campaign campaign = _mapper.Map<Campaign>(newCampaign);
            await _context.Campaigns.AddAsync(campaign);
            await _context.SaveChangesAsync();

            response.Data = await _context.Campaigns.Where(c => c.CampaignId.Equals(newCampaign.CampaignId)).Select(c => _mapper.Map<GetCampaignDto>(c)).FirstOrDefaultAsync();

            AddPlayerCampaignDto pc = new AddPlayerCampaignDto{
                PlayerId = playerId,
                CampaignId = response.Data.Id
            };

            await _service.AddPlayerCampaign(pc);

            response.Data = await _context.Campaigns.Where(c => c.CampaignId.Equals(newCampaign.CampaignId)).Select(c => _mapper.Map<GetCampaignDto>(c)).FirstOrDefaultAsync();

            return response;
        }
        public async Task<ServiceResponse<GetCampaignDto>> GetCampaign(string campaignId)
        {
            ServiceResponse<GetCampaignDto> response = new ServiceResponse<GetCampaignDto>();

            Campaign campaign = await _context.Campaigns
                .Include(c => c.PlayerCampaigns).ThenInclude(pc => pc.Player)
                .FirstOrDefaultAsync(c => c.CampaignId == campaignId);
            
            if (campaign == null)
            {
                response.Success = false;
                response.Message = "Campanha não encontrada.";
                return response;
            }

            response.Data = _mapper.Map<GetCampaignDto>(campaign);
            return response;
        }
    }
}