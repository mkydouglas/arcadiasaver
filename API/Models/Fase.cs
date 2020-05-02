using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Fase
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CampaignId { get; set; }
        public Campaign Campaign { get; set; }
        public List<FaseGoal> FaseGoals { get; set; }
    }
}
