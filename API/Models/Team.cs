using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<GoalTeam> GoalTeams { get; set; }
        public List<Hero> Heroes { get; set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; }
    }
}