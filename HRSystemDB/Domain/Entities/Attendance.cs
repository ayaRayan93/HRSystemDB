using HRSystemDB.Domain.Enums;

namespace HRSystemDB.Domain.Entities
{
    public class Attendance : BaseEntity
    {
        public int EmployeeId { get; set; }
        public DateTime AttendanceDate { get; set; }
        public TimeSpan CheckInTime { get; set; }
        public TimeSpan? CheckOutTime { get; set; }
        public int LateMinutes { get; set; }
        public int EarlyLeaveMinutes { get; set; }
        public decimal OvertimeHours { get; set; }
        public AttendanceStatus Status { get; set; }
        public bool Approved { get; set; }

        // Navigation Properties
        public virtual Employee Employee { get; set; }
    }
}
