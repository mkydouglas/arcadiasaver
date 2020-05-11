namespace backend.Models
{
    public class PhaseGoal
    {
        public int PhaseId { get; set; }
        public Phase Phase { get; set; }
        public int GoalId { get; set; }
        public Goal Goal { get; set; }
    }
}