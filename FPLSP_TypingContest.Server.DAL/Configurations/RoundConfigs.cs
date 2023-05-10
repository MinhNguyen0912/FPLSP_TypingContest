using FPLSP_TypingContest.Server.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FPLSP_TypingContest.Server.DAL.Configurations
{
    public partial class RoundConfigs : IEntityTypeConfiguration<Round>
    {
        public void Configure(EntityTypeBuilder<Round> builder)
        {
            builder.ToTable("Round");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.IdContest).IsRequired();
            builder.Property(c => c.Name).HasMaxLength(50).IsUnicode().IsRequired();
            builder.Property(c => c.Description).IsUnicode().IsRequired();
            builder.Property(c => c.ImageUrl).IsUnicode().IsRequired();

            builder.Property(c => c.MaxAccess).IsRequired();
            builder.Property(c => c.Availability).IsRequired();
            builder.Property(c => c.IsDisableBackspace).IsRequired();
            builder.Property(c => c.IsHavingSpecialChar).IsRequired();
            builder.Property(c => c.TotalTime).IsRequired();

            builder.Property(c => c.StartTime).IsRequired();
            builder.Property(c => c.EndTime).IsRequired();
            builder.Property(c => c.IsFinal).IsRequired();
            //BASE
            
            builder.Property(c => c.CreatedDate).IsRequired();
            builder.Property(c => c.CreatedBy).IsRequired();
            builder.Property(c => c.ModifiedDate).IsRequired(false);
            builder.Property(c => c.ModifiedBy).IsRequired(false);
            builder.Property(c => c.DeletedDate).IsRequired(false);
            builder.Property(c => c.DeletedBy).IsRequired(false);
            builder.Property(c => c.Status).IsRequired();

            builder.HasOne<Contest>(c => c.Contest)
                .WithMany(c => c.Rounds)
                .HasForeignKey(c => c.IdContest)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
