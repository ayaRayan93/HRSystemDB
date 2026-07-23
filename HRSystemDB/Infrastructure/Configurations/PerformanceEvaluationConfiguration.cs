using HRSystemDB.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRSystemDB.Infrastructure.Configurations
{
    public class PerformanceEvaluationConfiguration : IEntityTypeConfiguration<PerformanceEvaluation>
    {
        public void Configure(EntityTypeBuilder<PerformanceEvaluation> builder)
        {
            builder.ToTable("PerformanceEvaluations");

            builder.HasKey(pe => pe.Id);

            builder.Property(pe => pe.QualityOfWork)
                .HasPrecision(3, 1);

            builder.Property(pe => pe.Productivity)
                .HasPrecision(3, 1);

            builder.Property(pe => pe.Teamwork)
                .HasPrecision(3, 1);

            builder.Property(pe => pe.Communication)
                .HasPrecision(3, 1);

            builder.Property(pe => pe.ProblemSolving)
                .HasPrecision(3, 1);

            builder.Property(pe => pe.Attendance)
                .HasPrecision(3, 1);

            builder.Property(pe => pe.OverallScore)
                .HasPrecision(4, 2);

            builder.Property(pe => pe.Strengths)
                .HasMaxLength(500);

            builder.Property(pe => pe.Weaknesses)
                .HasMaxLength(500);

            builder.Property(pe => pe.DevelopmentPlan)
                .HasMaxLength(500);

            // Relationships
            builder.HasOne(pe => pe.Employee)
                .WithMany(e => e.EvaluationsAsEmployee)
                .HasForeignKey(pe => pe.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(pe => pe.Evaluator)
                .WithMany(e => e.EvaluationsAsEvaluator)
                .HasForeignKey(pe => pe.EvaluatorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
