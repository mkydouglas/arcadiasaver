using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeamGoal>().HasKey(tg => new { tg.TeamId, tg.GoalId});
            modelBuilder.Entity<PlayerCampaign>().HasKey(pc => new { pc.PlayerId, pc.CampaignId});
            modelBuilder.Entity<PhaseGoal>().HasKey(pg => new { pg.PhaseId, pg.GoalId });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.EnableDetailedErrors();
        }
        
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<TeamGoal> TeamGoals { get; set; }
        public DbSet<Hero> Heros { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<PlayerCampaign> PlayerCampaigns { get; set; }
        public DbSet<Phase> Phases { get; set; }
        public DbSet<PhaseGoal> PhaseGoals { get; set; }
    }
}