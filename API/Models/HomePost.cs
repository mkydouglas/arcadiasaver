using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class HomePost
    {
        public string CampaignId { get; set; }
        public string Fase { get; set; }
        public Goal Winner { get; set; }
        public Goal LeastDeaths { get; set; }
        public Goal MostCoin { get; set; }
        public Goal WonReward { get; set; }
        public Goal WonTitle { get; set; }
    }
}
