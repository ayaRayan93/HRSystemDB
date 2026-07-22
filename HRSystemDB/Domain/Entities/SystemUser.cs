using HRSystemDB.Domain.Enums;

namespace HRSystemDB.Domain.Entities
{
    public class SystemUser : BaseEntity
    {
        public int EmployeeId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public UserRole Role { get; set; }
        public DateTime? LastLoginDate { get; set; }

        // Navigation Properties
        public virtual Employee Employee { get; set; }
        public virtual ICollection<RefreshToken> RefreshTokens { get; set; }

        public SystemUser()
        {
            RefreshTokens = new HashSet<RefreshToken>();
        }
    }
}
