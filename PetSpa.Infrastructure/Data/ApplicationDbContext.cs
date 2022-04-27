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
        public DbSet<PetType> PetTypes { get; init; }
        public DbSet<Pet> Pets { get; init; }
        public DbSet<Location> Locations { get; init; }
        public DbSet<Salon> Salons { get; init; }
        public DbSet<Appointment> Appointments { get; init; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Review>()
                .HasOne(r => r.Service)
                .WithMany(r => r.Reviews)
                .HasForeignKey(r => r.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Review>()
                .HasOne(r => r.PetType)
                .WithMany(r => r.Reviews)
                .HasForeignKey(r => r.PetTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Pet>()
                .HasOne(p => p.User)
                .WithMany(u => u.Pets)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);


            builder
                .Entity<Salon>()
                .HasOne(s => s.Location)
                .WithMany(l => l.Salons)
                .HasForeignKey(p => p.LocationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Appointment>()
                .HasOne(a => a.Pet)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PetId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Appointment>()
                .HasOne(a => a.User)
                .WithMany(u => u.Appointments)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Appointment>()
                .HasOne(a => a.Salon)
                .WithMany(s => s.Appointments)
                .HasForeignKey(a => a.SalonId)
                .OnDelete(DeleteBehavior.Restrict);



            base.OnModelCreating(builder);
        }
    }
}