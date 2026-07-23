using HRSystemDB.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRSystemDB.Infrastructure.Configurations
{
    public class SystemUserConfiguration : IEntityTypeConfiguration<SystemUser>
    {
        public void Configure(EntityTypeBuilder<SystemUser> builder)
        {
            builder.ToTable("SystemUsers");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasIndex(u => u.Username)
                .IsUnique();

            builder.Property(u => u.PasswordHash)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(u => u.PasswordSalt)
                .IsRequired()
                .HasMaxLength(255);

            // Relationship: One-to-One with Employee
            builder.HasOne(u => u.Employee)
                .WithOne(e => e.User)
                .HasForeignKey<SystemUser>(u => u.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
