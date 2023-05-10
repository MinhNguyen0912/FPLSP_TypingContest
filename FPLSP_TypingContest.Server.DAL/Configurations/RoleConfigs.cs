using FPLSP_TypingContest.Server.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FPLSP_TypingContest.Server.DAL.Configurations
{
    public partial class RoleConfigs : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(50).IsUnicode().IsRequired();

            //BASE
            
            builder.Property(c => c.CreatedDate).IsRequired();
            builder.Property(c => c.CreatedBy).IsRequired();
            builder.Property(c => c.ModifiedDate).IsRequired(false);
            builder.Property(c => c.ModifiedBy).IsRequired(false);
            builder.Property(c => c.DeletedDate).IsRequired(false);
            builder.Property(c => c.DeletedBy).IsRequired(false);
            builder.Property(c => c.Status).IsRequired();
        }
    }
}
