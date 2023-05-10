using FPLSP_TypingContest.Server.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FPLSP_TypingContest.Server.DAL.Configurations
{
    public partial class ParticipantConfigs : IEntityTypeConfiguration<Participant>
    {
        public void Configure(EntityTypeBuilder<Participant> builder)
        {
            builder.ToTable("Participant");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.IdRound).IsRequired();
            builder.Property(c => c.IdUser).IsRequired();
            builder.Property(c => c.Email).HasMaxLength(50).IsUnicode(false).IsRequired();

            //BASE
            
            builder.Property(c => c.CreatedDate).IsRequired();
            builder.Property(c => c.CreatedBy).IsRequired();
            builder.Property(c => c.ModifiedDate).IsRequired(false);
            builder.Property(c => c.ModifiedBy).IsRequired(false);
            builder.Property(c => c.DeletedDate).IsRequired(false);
            builder.Property(c => c.DeletedBy).IsRequired(false);
            builder.Property(c => c.Status).IsRequired();

            builder.HasOne<Round>(c => c.Round)
            .WithMany(c => c.Participants)
            .HasForeignKey(c => c.IdRound)
            .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<User>(c => c.User)
            .WithMany(c => c.Participants)
            .HasForeignKey(c => c.IdUser)
            .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<RatingOfRound>(c => c.RatingOfRound)
            .WithOne(c => c.Participant)
            .HasForeignKey<RatingOfRound>(c => c.IdParticipant)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
