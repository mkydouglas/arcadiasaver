using backend.Dtos.Player;

namespace backend.Dtos.Campaign
{
    public class AddCampaignDto
    {
        public string CampaignId { get; set; }
        public string Name { get; set; }
        public int NumberOfPlayers { get; set; }
    }
}