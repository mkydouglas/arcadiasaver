using System.Threading.Tasks;
using backend.Dtos.Campaign;
using backend.Models;

namespace backend.Services.CampaignService
{
    public interface ICampaignService
    {
        Task<ServiceResponse<GetCampaignDto>> AddCampaign(AddCampaignDto newCampaign);
    }
}