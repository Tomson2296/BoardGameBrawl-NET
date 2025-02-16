using BoardGameBrawl.Domain.Common.BaseEntities;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using BoardGameBrawl.Domain.Entities.Group_Related;
using BoardGameBrawl.Domain.Entities.Match_Related;
using BoardGameBrawl.Domain.Entities.Player_Related;
using BoardGameBrawl.Domain.Entities.Player_Related.Preference_Related;
using BoardGameBrawl.Domain.Entities.Player_Related.Schedule_Related;
using BoardGameBrawl.Domain.Entities.Tournament_Related;
using BoardGameBrawl.Persistence.EntityConfiguration.Boardgame_Related;
using BoardGameBrawl.Persistence.EntityConfiguration.Common;
using BoardGameBrawl.Persistence.EntityConfiguration.Group_Related;
using BoardGameBrawl.Persistence.EntityConfiguration.Match_Related;
using BoardGameBrawl.Persistence.EntityConfiguration.Player_Related;
using BoardGameBrawl.Persistence.EntityConfiguration.Player_Related.Schedule_Related;
using BoardGameBrawl.Persistence.EntityConfiguration.Tournament_Related;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;

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

            //Common entities configuration
            modelBuilder.ApplyConfiguration(new BaseMatchEntityConfiguration());

            //Boardgame-related entities configuration
            modelBuilder.ApplyConfiguration(new BoardgameConfiguration());
            modelBuilder.ApplyConfiguration(new BoardgameDomainConfiguration());
            modelBuilder.ApplyConfiguration(new BoardgameDomainTagConfiguration());
            modelBuilder.ApplyConfiguration(new BoardgameCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new BoardgameCategoryTagConfiguration());
            modelBuilder.ApplyConfiguration(new BoardgameMechanicConfiguration());
            modelBuilder.ApplyConfiguration(new BoardgameMechanicTagConfigutaion());
            modelBuilder.ApplyConfiguration(new BoardgameModeratorConfiguration());

            //Group-related entities configuration
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new GroupParticipantConfiguration());

            //Match-related entities configuration
            modelBuilder.ApplyConfiguration(new MatchConfiguration());
            modelBuilder.ApplyConfiguration(new MatchParticipantConfiguration());
            modelBuilder.ApplyConfiguration(new MatchRuleSetConfiguration());
            modelBuilder.ApplyConfiguration(new MatchResultConfiguration());

            //Player-related entities configuration
            modelBuilder.ApplyConfiguration(new PlayerConfiguration());
            modelBuilder.ApplyConfiguration(new PlayerPreferenceConfiguration());
            modelBuilder.ApplyConfiguration(new PlayerFriendConfiguration());
            modelBuilder.ApplyConfiguration(new PlayerCollectionConfiguration());
            modelBuilder.ApplyConfiguration(new PlayerFavouriteBGConfiguration());
            modelBuilder.ApplyConfiguration(new PlayerRatingConfiguration());

            modelBuilder.ApplyConfiguration(new PlayerScheduleConfiguration());
            modelBuilder.ApplyConfiguration(new DailyAvailabilityConfiguration());
            modelBuilder.ApplyConfiguration(new TimeSlotConfiguration());

            //Tournament-related entities configuration
            modelBuilder.ApplyConfiguration(new TournamentConfiguration());
            modelBuilder.ApplyConfiguration(new TournamentParticipantConfiguration());
            modelBuilder.ApplyConfiguration(new TournamentMatchConfiguration());
            modelBuilder.ApplyConfiguration(new TournamentMatchParticipantConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }


        // Boardgame DbSets
        public DbSet<Boardgame> Boardgames { get; set; }

        public DbSet<BoardgameDomain> BoardgameDomains { get; set; }

        public DbSet<BoardgameDomainTag> BoardgameDomainTags { get; set; }

        public DbSet<BoardgameCategory> BoardgameCategories { get; set; }

        public DbSet<BoardgameCategoryTag> BoardgameCategoryTags { get; set; }

        public DbSet<BoardgameMechanic> BoardgameMechanics { get; set; }

        public DbSet<BoardgameMechanicTag> BoardgameMechanicTags { get; set; }

        public DbSet<BoardgameModerator> BoardgameModerators { get; set; }



        // Player DBSets 
        public DbSet<Player> Players { get; set; }

        public DbSet<PlayerPreference> PlayerPreferences { get; set; }

        public DbSet<PlayerFriend> PlayerFriends { get; set; }

        public DbSet<PlayerCollection> PlayerCollections { get; set; }

        public DbSet<PlayerFavouriteBG> PlayerFavouriteBGs { get; set; }

        public DbSet<PlayerRating> PlayerRatings { get; set; }



        // PLayer - Schedule related DBSets

        public DbSet<PlayerSchedule> PlayerSchedules { get; set; }

        public DbSet<DailyAvailability> DailyAvailabilities { get; set; }

        public DbSet<TimeSlot> TimeSlots { get; set; }



        // Group DBSets
        public DbSet<Group> Groups { get; set; }

        public DbSet<GroupParticipant> GroupParticipants { get; set; }



        // Match DBSets 
        public DbSet<Match> RegularMatches { get; set; }

        public DbSet<MatchParticipant> RegularMatchParticipants { get; set; }

        public DbSet<MatchRuleSet> MatchRuleSets { get; set; }

        public DbSet<MatchResult> MatchResults { get; set; }



        // Tournament DBSets
        public DbSet<Tournament> Tournaments { get; set; }

        public DbSet<TournamentParticipant> TournamentParticipants { get; set; }

        public DbSet<TournamentMatch> TournamentMatches { get; set; }

        public DbSet<TournamentMatchParticipant> TournamentMatchParticipants { get; set; }
    }
}
