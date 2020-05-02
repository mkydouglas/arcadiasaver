using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Home
    {
        public List<string> Fases { get; set; }
        public List<Team> Teams { get; set; }

        public Home()
        {
            Fases = new List<string>();
            Teams = new List<Team>();
        }
    }
}
