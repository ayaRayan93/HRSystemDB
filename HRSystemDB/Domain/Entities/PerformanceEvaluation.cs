using HRSystemDB.Domain.Enums;

namespace HRSystemDB.Domain.Entities
{
    public class PerformanceEvaluation : BaseEntity
    {
        public int EmployeeId { get; set; }
        public int EvaluatorId { get; set; }
        public EvaluationPeriod Period { get; set; }

        // KPI Scores (1-5)
        public decimal QualityOfWork { get; set; }
        public decimal Productivity { get; set; }
        public decimal Teamwork { get; set; }
        public decimal Communication { get; set; }
        public decimal ProblemSolving { get; set; }
        public decimal Attendance { get; set; }

        // Calculated Fields
        public decimal OverallScore { get; set; }
        public PerformanceGrade Grade { get; set; }

        public string Strengths { get; set; }
        public string Weaknesses { get; set; }
        public string DevelopmentPlan { get; set; }

        public DateTime EvaluationDate { get; set; }

        // Navigation Properties
        public virtual Employee Employee { get; set; }
        public virtual Employee Evaluator { get; set; }
    }
}
