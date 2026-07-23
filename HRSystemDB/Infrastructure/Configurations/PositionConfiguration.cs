using HRSystemDB.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRSystemDB.Infrastructure.Configurations
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.ToTable("Positions");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Grade)
                .IsRequired();

            builder.Property(p => p.MinSalary)
                .IsRequired()
                .HasPrecision(18, 2);

            builder.Property(p => p.MaxSalary)
                .IsRequired()
                .HasPrecision(18, 2);

            // Ensure MinSalary is less than MaxSalary
            builder.HasCheckConstraint("CK_Position_SalaryRange", "[MinSalary] < [MaxSalary]");

            // Index for faster lookups
            builder.HasIndex(p => p.Title)
                .HasDatabaseName("IX_Positions_Title");

            builder.HasIndex(p => p.Grade)
                .HasDatabaseName("IX_Positions_Grade");

            // Relationship with Employees (defined in EmployeeConfiguration)
            // but we can add a shadow property here for clarity
            builder.HasMany(p => p.Employees)
                .WithOne(e => e.Position)
                .HasForeignKey(e => e.PositionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
