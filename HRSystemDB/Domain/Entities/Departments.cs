using HRSystemDB.Domain.Entities;

namespace HRSystem.Domain.Entities
{
    public class Department : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        // Self-Reference for sub-departments
        public int? ParentDepartmentId { get; set; }
        public int? ManagerId { get; set; } // Will be set after Employee entity

        // Navigation Properties
        public virtual Department ParentDepartment { get; set; }
        public virtual Employee Manager { get; set; }
        public virtual ICollection<Department> SubDepartments { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }

        public Department()
        {
            SubDepartments = new HashSet<Department>();
            Employees = new HashSet<Employee>();
        }
    }
}
