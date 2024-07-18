using LeaveManagement.Models.Entities;

namespace LeaveManagement.Models
{
    public class AttendanceViewModel
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public DateTime Date { get; set; }
        public bool IsPresent { get; set; }
    }
}
