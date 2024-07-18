using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Models
{
    public class EmployeeViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(80)]
        public string Email { get; set; }
        [Required]
        [StringLength(12)]
        public string PhoneNo { get; set; }
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
        [Required]
        [StringLength(100)]
        public string Address { get; set; }
        public string Department { get; set; }
        public string Role { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
