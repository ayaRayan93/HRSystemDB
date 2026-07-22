using HRSystemDB.Domain.Enums;

namespace HRSystemDB.Domain.Entities
{
    public class Payroll : BaseEntity
    {
        public int EmployeeId { get; set; }
        public byte Month { get; set; } // 1-12
        public int Year { get; set; }

        // Income Components
        public decimal BasicSalary { get; set; }
        public decimal Allowances { get; set; }
        public decimal OvertimeAmount { get; set; }
        public decimal BonusAmount { get; set; }

        // Deductions
        public decimal AbsentDeduction { get; set; }
        public decimal LateDeduction { get; set; }
        public decimal LoanDeduction { get; set; }
        public decimal SocialInsurance { get; set; }
        public decimal Tax { get; set; }

        // Totals
        public decimal GrossSalary { get; set; }
        public decimal NetSalary { get; set; }

        public DateTime? PaymentDate { get; set; }
        public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Pending;
        public string Notes { get; set; }

        // Navigation Properties
        public virtual Employee Employee { get; set; }
    }
}
