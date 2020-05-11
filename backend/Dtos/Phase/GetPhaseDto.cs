using System.Collections.Generic;
using backend.Dtos.Campaign;
using backend.Dtos.Goal;

namespace backend.Dtos.Phase
{
    public class GetPhaseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public GetCampaignDto Campaign { get; set; }
        public List<GetGoalDto> Goals { get; set; }
    }
}