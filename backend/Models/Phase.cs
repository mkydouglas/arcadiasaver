namespace backend.Models
{
    public class Phase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Campaign Campaign { get; set; }
    }
}