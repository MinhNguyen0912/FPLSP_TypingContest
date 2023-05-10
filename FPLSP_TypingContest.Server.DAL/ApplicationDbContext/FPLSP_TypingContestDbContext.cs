using System;
using System.Collections.Generic;
using FPLSP_TypingContest.Server.DAL.Configurations;
using FPLSP_TypingContest.Server.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FPLSP_TypingContest.Server.DAL.ApplicationDbContext
{
    public partial class FPLSP_TypingContestDbContext : DbContext
    {
        public FPLSP_TypingContestDbContext()
        {
        }

        public FPLSP_TypingContestDbContext(DbContextOptions<FPLSP_TypingContestDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TrainingFacility> TrainingFacilities { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;
        public virtual DbSet<Organizer> Organizers { get; set; } = null!;
        public virtual DbSet<Contest> Contests { get; set; } = null!;
        public virtual DbSet<Round> Rounds { get; set; } = null!;
        public virtual DbSet<Level> Levels { get; set; } = null!;
        public virtual DbSet<TextTemplate> TextTemplates { get; set; } = null!;
        public virtual DbSet<ContentForRound> ContentForRounds { get; set; } = null!;
        public virtual DbSet<Participant> Participants { get; set; } = null!;
        public virtual DbSet<ScoreOfParticipant> ScoreOfParticipants { get; set; } = null!;
        public virtual DbSet<RatingOfRound> RatingOfRounds { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=66.42.55.38;Initial Catalog=FPLSP_TypingContest;User ID=test;Password=E=lPJeY>-g/9QxzE;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new TrainingFacilityConfigs());
            modelBuilder.ApplyConfiguration(new UserConfigs());
            modelBuilder.ApplyConfiguration(new RoleConfigs());
            modelBuilder.ApplyConfiguration(new UserRoleConfigs());
            modelBuilder.ApplyConfiguration(new OrganizerConfigs());
            modelBuilder.ApplyConfiguration(new ContestConfigs());
            modelBuilder.ApplyConfiguration(new RoundConfigs());
            modelBuilder.ApplyConfiguration(new LevelConfigs());
            modelBuilder.ApplyConfiguration(new TextTemplateConfigs());
            modelBuilder.ApplyConfiguration(new ContentForRoundConfigs());
            modelBuilder.ApplyConfiguration(new ParticipantConfigs());
            modelBuilder.ApplyConfiguration(new ScoreOfParticipantConfigs());
            modelBuilder.ApplyConfiguration(new RatingOfRoundConfigs());
        }
    }
}
