using System.Collections.Generic;

namespace API.Models
{
    public class Goal
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<FaseGoal> FaseGoals { get; set; }
        public List<GoalTeam> GoalTeams { get; set; }
    }
}