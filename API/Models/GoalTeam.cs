namespace API.Models
{
    public class GoalTeam
    {
        public int GoalId { get; set; }
        public Goal Goal { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}