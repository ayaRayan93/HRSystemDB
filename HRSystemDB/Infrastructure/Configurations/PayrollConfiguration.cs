using HRSystemDB.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRSystemDB.Infrastructure.Configurations
{
    public class PayrollConfiguration : IEntityTypeConfiguration<Payroll>
    {
        public void Configure(EntityTypeBuilder<Payroll> builder)
        {
            builder.ToTable("Payrolls");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.BasicSalary)
                .HasPrecision(18, 2);

            builder.Property(p => p.Allowances)
                .HasPrecision(18, 2);

            builder.Property(p => p.OvertimeAmount)
                .HasPrecision(18, 2);

            builder.Property(p => p.BonusAmount)
                .HasPrecision(18, 2);

            builder.Property(p => p.AbsentDeduction)
                .HasPrecision(18, 2);

            builder.Property(p => p.LateDeduction)
                .HasPrecision(18, 2);

            builder.Property(p => p.LoanDeduction)
                .HasPrecision(18, 2);

            builder.Property(p => p.SocialInsurance)
                .HasPrecision(18, 2);

            builder.Property(p => p.Tax)
                .HasPrecision(18, 2);

            builder.Property(p => p.GrossSalary)
                .HasPrecision(18, 2);

            builder.Property(p => p.NetSalary)
                .HasPrecision(18, 2);

            builder.Property(p => p.Notes)
                .HasMaxLength(500);

            // Unique constraint: one payroll per employee per month
            builder.HasIndex(p => new { p.EmployeeId, p.Month, p.Year })
                .IsUnique();

            // Relationship
            builder.HasOne(p => p.Employee)
                .WithMany(e => e.Payrolls)
                .HasForeignKey(p => p.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
