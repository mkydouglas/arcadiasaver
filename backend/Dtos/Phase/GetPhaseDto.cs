using backend.Dtos.Campaign;

namespace backend.Dtos.Phase
{
    public class GetPhaseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public GetCampaignDto Campaign { get; set; }
    }
}