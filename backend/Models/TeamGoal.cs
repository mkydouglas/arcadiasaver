namespace backend.Models
{
    public class TeamGoal
    {
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public int GoalId { get; set; }
        public Goal Goal { get; set; }
    }
}