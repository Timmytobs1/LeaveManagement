namespace LeaveManagement.Models.Entities
{
    public class Attendance
    {
        public Guid Id { get; set; }   
        public Guid EmployeeId { get; set; }  
        public Employee Employee { get; set; }  
        public DateTime Date { get; set; }  = DateTime.Now;
        public bool IsPresent { get; set; }    
    }
}
