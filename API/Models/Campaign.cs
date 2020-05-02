using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Campaign
    {
        [Key]
        public int Id { get; set; }
        public string CampaignId { get; set; }
        public string Name { get; set; }
        public int NumberOfPlayers { get; set; }
        public int PlayersQuantity { get; set; }
        public string Player { get; set; }
        public string Player2 { get; set; }
        public string Player3 { get; set; }
        public string Player4 { get; set; }
        public List<PlayerCampaign> PlayerCampaigns { get; set; }
        public List<Fase> Fases { get; set; }

        public List<string> BuscaPlayers()
        {
            List<string> Players = new List<string>();
            Players.Add(Player);
            Players.Add(Player2);
            Players.Add(Player3);
            Players.Add(Player4);

            return Players;
        }

        public static List<string> PreencheLista()
        {
            List<string> campaigns = new List<string>();
            campaigns.Add("Arcadia Quest");
            campaigns.Add("Arcadia Quest: Inferno");
            campaigns.Add("Beyond the Graves");
            campaigns.Add("Pets");
            campaigns.Add("Riders");

            return campaigns;
        }
    }
}
