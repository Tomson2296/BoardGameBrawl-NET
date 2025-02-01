using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using BoardGameBrawl.Domain.Entities.Group_Related;
using BoardGameBrawl.Domain.Entities.Match_Related;
using BoardGameBrawl.Domain.Entities.Player_Related;
using BoardGameBrawl.Domain.Entities.Tournament_Related;
using BoardGameBrawl.Persistence.EntityConfiguration.Boardgame_Related;
using BoardGameBrawl.Persistence.EntityConfiguration.Group_Related;
using BoardGameBrawl.Persistence.EntityConfiguration.Match_Related;
using BoardGameBrawl.Persistence.EntityConfiguration.Player_Related;
using BoardGameBrawl.Persistence.EntityConfiguration.Tournament_Related;
using Microsoft.EntityFrameworkCore;

namespace BoardGameBrawl.Persistence
{
    public class MainAppDBContext : AuditableDBContext
    {
        public MainAppDBContext(DbContextOptions<MainAppDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("dbo");

            //Boardgame-related entities configuration
            modelBuilder.ApplyConfiguration(new BoardgameConfiguration());
            modelBuilder.ApplyConfiguration(new BoardgameCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new BoardgameCategoryTagConfiguration());
            modelBuilder.ApplyConfiguration(new BoardgameMechanicConfiguration());
            modelBuilder.ApplyConfiguration(new BoardgameMechanicTagConfigutaion());

            //Group-related entities configuration
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new GroupParticipantConfiguration());

            //Match-related entities configuration
            modelBuilder.ApplyConfiguration(new MatchConfiguration());
            modelBuilder.ApplyConfiguration(new MatchRuleConfiguration());

            //Player-related entities configuration
            modelBuilder.ApplyConfiguration(new PlayerConfiguration());
            modelBuilder.ApplyConfiguration(new PlayerPreferenceConfiguration());

            //Tournament-related entities configuration
            modelBuilder.ApplyConfiguration(new TournamentConfiguration());
            modelBuilder.ApplyConfiguration(new TournamentMatchConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Boardgame> Boardgames { get; set; }

        public DbSet<MatchRule> MatchRules { get; set; }

        public DbSet<BoardgameCategory> BoardgameCategories { get; set; }

        public DbSet<BoardgameCategoryTag> BoardgameCategoryTags { get; set; }

        public DbSet<BoardgameMechanic> BoardgameMechanics { get; set; }

        public DbSet<BoardgameMechanicTag> BoardgameMechanicTags { get; set; }


        public DbSet<Player> Players { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<GroupParticipant> GroupParticipants { get; set; }

        public DbSet<PlayerRreference> PlayerRreferences { get; set; }


        public DbSet<Match> Matches { get; set; }

        public DbSet<Tournament> Tournaments { get; set; }

        public DbSet<TournamentMatch> TournamentMatches { get; set; }
    }
}
