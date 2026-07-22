namespace HRSystemDB.Domain.Entities
{
    public class Employee : BaseEntity
    {
        public string EmployeeCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string Email { get; set; }
        public string Phone { get; set; }
        public string NationalId { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? TerminationDate { get; set; }

        // Financial Information
        public decimal BasicSalary { get; set; }
        public decimal Allowances { get; set; }
        public decimal TotalSalary => BasicSalary + Allowances;

        // Banking Information
        public string BankName { get; set; }
        public string AccountNumber { get; set; }

        // Foreign Keys
        public int DepartmentId { get; set; }
        public int PositionId { get; set; }
        public int? ManagerId { get; set; }

        // Navigation Properties
        public virtual Department Department { get; set; }
        public virtual Position Position { get; set; }
        public virtual Employee Manager { get; set; }

        // Collections
        public virtual ICollection<Employee> Subordinates { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<Leave> Leaves { get; set; }
        public virtual ICollection<Payroll> Payrolls { get; set; }
        public virtual ICollection<PerformanceEvaluation> EvaluationsAsEmployee { get; set; }
        public virtual ICollection<PerformanceEvaluation> EvaluationsAsEvaluator { get; set; }
        public virtual SystemUser User { get; set; }

        public Employee()
        {
            Subordinates = new HashSet<Employee>();
            Attendances = new HashSet<Attendance>();
            Leaves = new HashSet<Leave>();
            Payrolls = new HashSet<Payroll>();
            EvaluationsAsEmployee = new HashSet<PerformanceEvaluation>();
            EvaluationsAsEvaluator = new HashSet<PerformanceEvaluation>();
        }
    }
}
