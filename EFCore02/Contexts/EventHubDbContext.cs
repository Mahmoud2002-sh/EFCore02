using EFCore02.Configurations;
using EFCore02.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore02.Contexts
{
    public class EventHubDbContext:DbContext
    {
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<OrganizerProfile> OrganizerProfiles { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Badge> Badges { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=EventHubDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<OrganizerProfile>(entity =>
            {
                entity.HasKey(p => p.OrganizerProfileId);

                entity.Property(p => p.Biography)
                      .HasMaxLength(1000);

                entity.Property(p => p.Website)
                      .HasMaxLength(300);

                entity.Property(p => p.LogoUrl)
                      .HasMaxLength(500);

                entity.HasOne(p => p.Organizer)
                      .WithOne(o => o.OrganizerProfile)
                      .HasForeignKey<OrganizerProfile>(
                          p => p.OrganizerId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);
            });

            
            modelBuilder.ApplyConfiguration(new EventConfiguration());

            modelBuilder.ApplyConfiguration(new BadgeConfiguration());
        }

    }
}
