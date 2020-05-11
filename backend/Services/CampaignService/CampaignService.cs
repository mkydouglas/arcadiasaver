using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using backend.Data;
using backend.Dtos.Campaign;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services.CampaignService
{
    public class CampaignService : ICampaignService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public CampaignService(DataContext context, IMapper mapper)
        {
            this._mapper = mapper;
            this._context = context;

        }
        public async Task<ServiceResponse<GetCampaignDto>> AddCampaign(AddCampaignDto newCampaign)
        {
            ServiceResponse<GetCampaignDto> response = new ServiceResponse<GetCampaignDto>();
            Campaign campaign = _mapper.Map<Campaign>(newCampaign);
            await _context.Campaigns.AddAsync(campaign);
            await _context.SaveChangesAsync();

            response.Data = await _context.Campaigns.Where(c => c.CampaignId.Equals(newCampaign.CampaignId)).Select(c => _mapper.Map<GetCampaignDto>(c)).FirstOrDefaultAsync();

            return response;
        }
    }
}