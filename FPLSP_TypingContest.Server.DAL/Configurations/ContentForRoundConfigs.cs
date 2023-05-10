using FPLSP_TypingContest.Server.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace FPLSP_TypingContest.Server.DAL.Configurations
{
    public partial class ContentForRoundConfigs : IEntityTypeConfiguration<ContentForRound>
    {
        public void Configure(EntityTypeBuilder<ContentForRound> builder)
        {
            builder.ToTable("ContentForRound");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.IdTextTemplate).IsRequired();
            builder.Property(c => c.IdRound).IsRequired();
            builder.Property(c => c.Content).IsUnicode().IsRequired();

            //BASE
            
            builder.Property(c => c.CreatedDate).IsRequired();
            builder.Property(c => c.CreatedBy).IsRequired();
            builder.Property(c => c.ModifiedDate).IsRequired(false);
            builder.Property(c => c.ModifiedBy).IsRequired(false);
            builder.Property(c => c.DeletedDate).IsRequired(false);
            builder.Property(c => c.DeletedBy).IsRequired(false);
            builder.Property(c => c.Status).IsRequired();

            builder.HasOne<TextTemplate>(c => c.TextTemplate)
                .WithMany(c => c.ContentForRounds)
                .HasForeignKey(c => c.IdTextTemplate)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<Round>(c => c.Round)
                .WithMany(c => c.ContentForRounds)
                .HasForeignKey(c => c.IdRound)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
