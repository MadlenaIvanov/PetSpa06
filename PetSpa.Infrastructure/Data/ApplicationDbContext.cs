using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetSpa.Infrastructure.Identity;

namespace PetSpa.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<Review> Reviews { get; init; }
        public DbSet<Service> Services { get; init; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Review>()
                .HasOne(r => r.Service)
                .WithMany(r => r.Reviews)
                .HasForeignKey(r => r.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);


            base.OnModelCreating(builder);
        }
    }
}