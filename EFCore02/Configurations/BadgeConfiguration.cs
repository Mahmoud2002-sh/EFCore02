using EFCore02.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore02.Configurations
{
    public class BadgeConfiguration : IEntityTypeConfiguration<Badge>
    {
        public void Configure(EntityTypeBuilder<Badge> builder)
        {
            builder.HasKey(b => b.BadgeId);

            builder.Property(b => b.BadgeNumber)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.HasIndex(b => b.BadgeNumber)
                   .IsUnique();

            builder.Property(b => b.IssueDate)
                   .IsRequired();

            builder.Property(b => b.Tier)
                   .HasConversion<string>()
                   .HasMaxLength(20)
                   .IsRequired();

            
            builder.HasOne(b => b.Attendee)
                   .WithOne(a => a.Badge)
                   .HasForeignKey<Badge>(b => b.AttendeeId)
                   .IsRequired();

        }
    }
}
