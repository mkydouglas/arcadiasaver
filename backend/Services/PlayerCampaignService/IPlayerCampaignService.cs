using System.Threading.Tasks;
using backend.Dtos.Campaign;
using backend.Dtos.PlayerCampaign;
using backend.Models;

namespace backend.Services.PlayerCampaignService
{
    public interface IPlayerCampaignService
    {
        Task<ServiceResponse<GetCampaignDto>> AddPlayerCampaign(AddPlayerCampaignDto newPlayerCampaign);
    }
}