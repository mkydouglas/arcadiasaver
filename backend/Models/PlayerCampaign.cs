namespace backend.Models
{
    public class PlayerCampaign
    {
        public int PlayerId { get; set; }
        public Player Player { get; set; }
        public int CampaignId { get; set; }
        public Campaign Campaign { get; set; }
    }
}