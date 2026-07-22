namespace HRSystemDB.Domain.Entities
{
    public class RefreshToken : BaseEntity
    {
        public int UserId { get; set; }
        public string Token { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsRevoked { get; set; }

        // Navigation Properties
        public virtual SystemUser User { get; set; }
    }
}
