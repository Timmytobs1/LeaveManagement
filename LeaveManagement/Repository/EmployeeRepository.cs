using LeaveManagement.Data;
using LeaveManagement.Interface;
using LeaveManagement.Models;
using LeaveManagement.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Ocsp;

namespace LeaveManagement.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;
        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Employee> CreateEmployee(EmployeeViewModel employeeViewModel)
        {
            var employeeModel = new Employee
            {
                FirstName = employeeViewModel.FirstName,
                LastName = employeeViewModel.LastName,
                Email = employeeViewModel.Email,
                DateOfBirth = employeeViewModel.DateOfBirth,
                PhoneNo = employeeViewModel.PhoneNo,
                Address = employeeViewModel.Address,
                Department = employeeViewModel.Department,
                Role = employeeViewModel.Role,
                Password = employeeViewModel.Password,
                ConfirmPassword = employeeViewModel.ConfirmPassword
            };
            await _context.Employees.AddAsync(employeeModel);
            await _context.SaveChangesAsync();
            return employeeModel;
        }

        public async Task<Employee?> DeleteEmployee(Guid id)
        {
            var user = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                return null;
            }

            _context.Employees.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public Task<List<Employee>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public async Task<Employee?> GetById(Guid id)
        {
            var user = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public async Task<Employee> Login(LoginViewModel login)
        {
            var templogin = await _context.Employees.FirstOrDefaultAsync(x => x.Email == login.Email && x.Password == login.Password);
           return templogin; 
        
        }

        public async Task<Employee?> UpdateEmployee(Guid id, EmployeeViewModel employeeViewModel)
        {
            var user = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                return null;
            }

           user.FirstName = employeeViewModel.FirstName;
            user.LastName = employeeViewModel.LastName; 
            user.Email = employeeViewModel.Email;
            user.Address = employeeViewModel.Address;
            user.PhoneNo = employeeViewModel.PhoneNo;
            user.Role = employeeViewModel.Role;

            await _context.SaveChangesAsync();
            return user;
        }
    }
}
