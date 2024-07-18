using LeaveManagement.Models.Entities;

namespace LeaveManagement.Models
{
    public class UserLoginHistoryViewModel
    {
        public Guid Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public DateTime LoginTime { get; set; } = DateTime.Now;
        public DateTime LogoutTime { get; set; } = DateTime.Now;

    }
}
