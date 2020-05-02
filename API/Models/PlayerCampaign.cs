using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class PlayerCampaign
    {
        public int PlayerId { get; set; }
        public Player Player { get; set; }

        public int CampaignId { get; set; }
        public Campaign Campaign { get; set; }
    }
}
