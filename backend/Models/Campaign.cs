using System.Collections.Generic;

namespace backend.Models
{
    public class Campaign
    {
        public int Id { get; set; }
        public string CampaignId { get; set; }
        public string Name { get; set; }
        public int NumberOfPlayers { get; set; }
        public List<PlayerCampaign> PlayerCampaigns { get; set; }
        public List<Phase> Phases { get; set; }
    }
}