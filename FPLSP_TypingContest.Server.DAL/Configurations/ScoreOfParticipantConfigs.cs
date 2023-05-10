using FPLSP_TypingContest.Server.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FPLSP_TypingContest.Server.DAL.Configurations
{
    public partial class ScoreOfParticipantConfigs : IEntityTypeConfiguration<ScoreOfParticipant>
    {
        public void Configure(EntityTypeBuilder<ScoreOfParticipant> builder)
        {
            builder.ToTable("ScoreOfParticipant");
            builder.HasKey(c => new { c.Id});

            builder.Property(c => c.IdParticipant).IsRequired();
            builder.Property(c => c.IdContentForRound).IsRequired();
            builder.Property(c => c.Accuracy).IsRequired();
            builder.Property(c => c.Speed).IsRequired();

            //BASE
            
            builder.Property(c => c.CreatedDate).IsRequired();
            builder.Property(c => c.CreatedBy).IsRequired();
            builder.Property(c => c.ModifiedDate).IsRequired(false);
            builder.Property(c => c.ModifiedBy).IsRequired(false);
            builder.Property(c => c.DeletedDate).IsRequired(false);
            builder.Property(c => c.DeletedBy).IsRequired(false);
            builder.Property(c => c.Status).IsRequired();

            builder.HasOne<ContentForRound>(c => c.ContentForRound)
                .WithMany(c => c.ScoreOfParticipants)
                .HasForeignKey(c => c.IdContentForRound)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Participant>(c => c.Participant)
                .WithMany(c => c.ScoreOfParticipants)
                .HasForeignKey(c => c.IdParticipant)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
