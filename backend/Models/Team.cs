using System.Collections.Generic;

namespace backend.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Player Player { get; set; }
    }
}