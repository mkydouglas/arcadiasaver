using System.Collections.Generic;

namespace backend.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public List<Team> Teams { get; set; }
        public List<PlayerCampaign> PlayerCampaigns { get; set; }
    }
}