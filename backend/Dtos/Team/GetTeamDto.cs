using System.Collections.Generic;
using backend.Dtos.Goal;
using backend.Dtos.Hero;

namespace backend.Dtos.Team
{
    public class GetTeamDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<GetGoalDto> Goals { get; set; }
        public List<GetHeroDto> Heros { get; set; }
    }
}