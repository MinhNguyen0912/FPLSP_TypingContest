using FPLSP_TypingContest.Server.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FPLSP_TypingContest.Server.DAL.Configurations
{
    public partial class UserRoleConfigs : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("UserRole");
            builder.HasKey(c => new { c.IdRole, c.IdUser});

            builder.Property(c => c.IdRole).IsRequired();
            builder.Property(c => c.IdUser).IsRequired();

            //BASE
            
            builder.Property(c => c.CreatedDate).IsRequired();
            builder.Property(c => c.CreatedBy).IsRequired();
            builder.Property(c => c.ModifiedDate).IsRequired(false);
            builder.Property(c => c.ModifiedBy).IsRequired(false);
            builder.Property(c => c.DeletedDate).IsRequired(false);
            builder.Property(c => c.DeletedBy).IsRequired(false);
            builder.Property(c => c.Status).IsRequired();

            builder.HasOne<Role>(c => c.Role)
                .WithMany(c => c.UserRoles)
                .HasForeignKey(c => c.IdRole)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne<User>(c => c.User)
                .WithMany(c => c.UserRoles)
                .HasForeignKey(c => c.IdUser)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
