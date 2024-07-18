using LeaveManagement.Models;
using LeaveManagement.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagement.Interface
{
    public interface IEmployeeRepository
    {
        public Task<List<Employee>> GetAllUsers();
        public Task<Employee?> GetById(Guid id);
        public Task<Employee> CreateEmployee(EmployeeViewModel employeeViewModel);
        public Task<Employee?> UpdateEmployee(Guid id, EmployeeViewModel employeeViewModel);
        public Task<Employee?> DeleteEmployee(Guid id);
        public Task<Employee?> Login(LoginViewModel login);
      


    }
}
