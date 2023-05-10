using FPLSP_TypingContest.Server.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace FPLSP_TypingContest.Server.DAL.Configurations
{
    public partial class ContestConfigs : IEntityTypeConfiguration<Contest>
    {
        public void Configure(EntityTypeBuilder<Contest> builder)
        {
            builder.ToTable("Contest");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.IdOrganizer).IsRequired();
            builder.Property(c => c.Name).HasMaxLength(50).IsUnicode().IsRequired();
            builder.Property(c => c.Description).IsUnicode().IsRequired();
            builder.Property(c => c.ImageUrl).IsUnicode().IsRequired();
            builder.Property(c => c.StartTime).IsRequired();
            builder.Property(c => c.EndTime).IsRequired();

            //BASE
            
            builder.Property(c => c.CreatedDate).IsRequired();
            builder.Property(c => c.CreatedBy).IsRequired();
            builder.Property(c => c.ModifiedDate).IsRequired(false);
            builder.Property(c => c.ModifiedBy).IsRequired(false);
            builder.Property(c => c.DeletedDate).IsRequired(false);
            builder.Property(c => c.DeletedBy).IsRequired(false);
            builder.Property(c => c.Status).IsRequired();

            builder.HasOne<Organizer>(c => c.Organizer)
                .WithMany(c => c.Contests)
                .HasForeignKey(c => c.IdOrganizer)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
