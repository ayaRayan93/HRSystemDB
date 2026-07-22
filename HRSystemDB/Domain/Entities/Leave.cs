using HRSystemDB.Domain.Enums;

namespace HRSystemDB.Domain.Entities
{
    public class Leave : BaseEntity
    {
        public int EmployeeId { get; set; }
        public LeaveType Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalDays { get; set; }
        public string Reason { get; set; }
        public bool IsPaid { get; set; }

        // Approval Workflow
        public LeaveStatus Status { get; set; } = LeaveStatus.Pending;
        public int? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string RejectionReason { get; set; }

        // Navigation Properties
        public virtual Employee Employee { get; set; }
        public virtual Employee Approver { get; set; }
    }
}
