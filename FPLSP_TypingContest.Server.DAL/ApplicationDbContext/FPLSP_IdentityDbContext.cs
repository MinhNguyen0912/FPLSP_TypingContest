using FPLSP_TypingContest.Server.DAL.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FPLSP_TypingContest.Server.DAL.ApplicationDbContext
{
    public class FPLSP_IdentityDbContext : IdentityDbContext
    {
        public FPLSP_IdentityDbContext()
        {
            
        }
        public FPLSP_IdentityDbContext(DbContextOptions<IdentityDbContext> options)
        : base(options)
        {
        }
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
            //Gán Index vào cột Email của bảng AspNetUsers
            modelBuilder.Entity<IdentityUser>()
                .ToTable("AspNetUsers")
                .HasIndex(u => u.Email)
                .IsUnique();
        }
        
    }
}
