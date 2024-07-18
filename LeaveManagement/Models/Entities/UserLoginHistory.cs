namespace LeaveManagement.Models.Entities
{
    public class UserLoginHistory
    {
        public Guid Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime LoginTime { get; set; } = DateTime.Now;
        public DateTime LogoutTime { get; set; } = DateTime.Now;
    }
}
