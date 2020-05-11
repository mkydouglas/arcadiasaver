using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using backend.Data;
using backend.Dtos.Campaign;
using backend.Dtos.PlayerCampaign;
using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace backend.Services.PlayerCampaignService
{
    public class PlayerCampaignService : IPlayerCampaignService
    {
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly DataContext _context;
        public PlayerCampaignService(IMapper mapper, IHttpContextAccessor httpContextAccessor, DataContext context)
        {
            this._context = context;
            this._httpContextAccessor = httpContextAccessor;
            this._mapper = mapper;

        }
        public async Task<ServiceResponse<GetCampaignDto>> AddPlayerCampaign(AddPlayerCampaignDto newPlayerCampaign)
        {
            ServiceResponse<GetCampaignDto> response = new ServiceResponse<GetCampaignDto>();
            try
            {
                Player player = await _context.Players
                    .FirstOrDefaultAsync(p => p.Id == newPlayerCampaign.PlayerId);
                if (player == null)
                {
                    response.Success = false;
                    response.Message = "Player not found.";
                    return response;
                }

                Campaign campaign = await _context.Campaigns
                    .Include(c => c.PlayerCampaigns).ThenInclude(pc => pc.Player)
                    .FirstOrDefaultAsync(c => c.Id == newPlayerCampaign.CampaignId);
                if (campaign == null)
                {
                    response.Success = false;
                    response.Message = "Campaign not found.";
                    return response;
                }

                PlayerCampaign playerCampaign = new PlayerCampaign
                {
                    Player = player,
                    Campaign = campaign
                };

                await _context.PlayerCampaigns.AddAsync(playerCampaign);
                await _context.SaveChangesAsync();

                response.Data = _mapper.Map<GetCampaignDto>(campaign);
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