using HRSystemDB.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRSystemDB.Infrastructure.Configurations
{
    public class AttendanceConfiguration : IEntityTypeConfiguration<Attendance>
    {
        public void Configure(EntityTypeBuilder<Attendance> builder)
        {
            builder.ToTable("Attendances");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.CheckInTime)
                .IsRequired();

            builder.Property(a => a.LateMinutes)
                .HasDefaultValue(0);

            builder.Property(a => a.EarlyLeaveMinutes)
                .HasDefaultValue(0);

            builder.Property(a => a.OvertimeHours)
                .HasDefaultValue(0)
                .HasPrecision(4, 2);

            // Unique constraint: one attendance per employee per day
            builder.HasIndex(a => new { a.EmployeeId, a.AttendanceDate })
                .IsUnique();

            // Relationship
            builder.HasOne(a => a.Employee)
                .WithMany(e => e.Attendances)
                .HasForeignKey(a => a.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
