using FPLSP_TypingContest.Server.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FPLSP_TypingContest.Server.DAL.Configurations
{
    public partial class TextTemplateConfigs : IEntityTypeConfiguration<TextTemplate>
    {
        public void Configure(EntityTypeBuilder<TextTemplate> builder)
        {
            builder.ToTable("TextTemplate");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.IdLevel).IsUnicode().IsRequired();

            builder.Property(c => c.Title).HasMaxLength(50).IsUnicode().IsRequired();
            builder.Property(c => c.Content).IsUnicode().IsRequired();

            //BASE
            
            builder.Property(c => c.CreatedDate).IsRequired();
            builder.Property(c => c.CreatedBy).IsRequired();
            builder.Property(c => c.ModifiedDate).IsRequired(false);
            builder.Property(c => c.ModifiedBy).IsRequired(false);
            builder.Property(c => c.DeletedDate).IsRequired(false);
            builder.Property(c => c.DeletedBy).IsRequired(false);
            builder.Property(c => c.Status).IsRequired();

            builder.HasOne<Level>(c => c.Level)
                .WithMany(c => c.TextTemplates)
                .HasForeignKey(c => c.IdLevel)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
