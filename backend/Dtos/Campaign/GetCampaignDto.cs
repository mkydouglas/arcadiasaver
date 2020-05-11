using System.Collections.Generic;
using backend.Dtos.Player;

namespace backend.Dtos.Campaign
{
    public class GetCampaignDto
    {
        public int Id { get; set; }
        public string CampaignId { get; set; }
        public string Name { get; set; }
        public int NumberOfPlayers { get; set; }
        public List<GetPlayerDto> Players { get; set; }
    }
}