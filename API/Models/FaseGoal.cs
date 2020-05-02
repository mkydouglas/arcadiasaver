namespace API.Models
{
    public class FaseGoal
    {
        public int FaseId { get; set; }
        public Fase Fase { get; set; }

        public int GoalId { get; set; }
        public Goal Goal { get; set; }
    }
}