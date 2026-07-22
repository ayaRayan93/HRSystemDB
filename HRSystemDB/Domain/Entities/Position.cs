namespace HRSystemDB.Domain.Entities
{
    public class Position : BaseEntity
    {
        public string Title { get; set; }
        public byte Grade { get; set; } // 1-10
        public decimal MinSalary { get; set; }
        public decimal MaxSalary { get; set; }

        // Navigation Properties
        public virtual ICollection<Employee> Employees { get; set; }

        public Position()
        {
            Employees = new HashSet<Employee>();
        }
    }
}
