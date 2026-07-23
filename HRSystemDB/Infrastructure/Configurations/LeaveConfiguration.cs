using HRSystemDB.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRSystemDB.Infrastructure.Configurations
{
    public class LeaveConfiguration : IEntityTypeConfiguration<Leave>
    {
        public void Configure(EntityTypeBuilder<Leave> builder)
        {
            builder.ToTable("Leaves");

            builder.HasKey(l => l.Id);

            builder.Property(l => l.Reason)
                .HasMaxLength(500);

            builder.Property(l => l.RejectionReason)
                .HasMaxLength(500);

            builder.Property(l => l.TotalDays)
                .HasPrecision(4, 1);

            builder.Property(l => l.IsPaid)
                .HasDefaultValue(true);

            builder.Property(l => l.Status)
                .HasDefaultValue(Domain.Enums.LeaveStatus.Pending);

            // Relationships
            builder.HasOne(l => l.Employee)
                .WithMany(e => e.Leaves)
                .HasForeignKey(l => l.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(l => l.Approver)
                .WithMany()
                .HasForeignKey(l => l.ApprovedBy)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
