namespace LeaveManagement.Models.Entities
{
    public class LeaveRequest
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now;
        public string LeaveType { get; set; }
        public string Status { get; set; }
        public string Reason { get; set; }
    }
}
