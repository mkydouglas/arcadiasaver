using System.Collections.Generic;

namespace backend.Models
{
    public class Goal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TeamGoal> TeamGoals { get; set; }
        public List<PhaseGoal> PhaseGoals { get; set; }
    }
}