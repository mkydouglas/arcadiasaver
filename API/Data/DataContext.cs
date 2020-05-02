using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //relacionamento muitos para muitos de Player com Campaign
            modelBuilder.Entity<PlayerCampaign>()
                        .HasKey(t => new { t.CampaignId, t.PlayerId });

            modelBuilder.Entity<PlayerCampaign>()
                        .HasOne(pt => pt.Campaign)
                        .WithMany(p => p.PlayerCampaigns)
                        .HasForeignKey(pt => pt.CampaignId);

            modelBuilder.Entity<PlayerCampaign>()
                        .HasOne(pt => pt.Player)
                        .WithMany(p => p.PlayerCampaigns)
                        .HasForeignKey(pt => pt.PlayerId);

            //relacionamento um para muitos de Fase com Campaign
            modelBuilder.Entity<Campaign>()
                        .HasMany(c => c.Fases)
                        .WithOne(f => f.Campaign);

            //relacionamento muitos para muitos de Fase com Goal
            modelBuilder.Entity<FaseGoal>()
                        .HasKey(t => new { t.FaseId, t.GoalId });

            modelBuilder.Entity<FaseGoal>()
                        .HasOne(pt => pt.Fase)
                        .WithMany(p => p.FaseGoals)
                        .HasForeignKey(pt => pt.FaseId);

            modelBuilder.Entity<FaseGoal>()
                        .HasOne(pt => pt.Goal)
                        .WithMany(p => p.FaseGoals)
                        .HasForeignKey(pt => pt.GoalId);

            //relacionamento muitos para muitos de Team com Goal
            modelBuilder.Entity<GoalTeam>()
                        .HasKey(t => new { t.TeamId, t.GoalId });

            modelBuilder.Entity<GoalTeam>()
                        .HasOne(pt => pt.Goal)
                        .WithMany(p => p.GoalTeams)
                        .HasForeignKey(pt => pt.GoalId);

            modelBuilder.Entity<GoalTeam>()
                        .HasOne(pt => pt.Team)
                        .WithMany(p => p.GoalTeams)
                        .HasForeignKey(pt => pt.TeamId);

            //relacionamento um para muitos de Team com Hero
            modelBuilder.Entity<Team>()
                        .HasMany(t => t.Heroes)
                        .WithOne(h => h.Team);

            //relacionamento um para muitos de Team com Player
            modelBuilder.Entity<Player>()
                        .HasMany(p => p.Teams)
                        .WithOne(t => t.Player);
        }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Player> Player { get; set; }
        public DbSet<Fase> Fases { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Hero> Heroes { get; set; }
    }
}