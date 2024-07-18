using LeaveManagement.Data;
using LeaveManagement.Interface;
using LeaveManagement.Models;
using LeaveManagement.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace LeaveManagement.Controllers
{

    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository repo;
        private readonly ApplicationDbContext _context;

        public EmployeeController(IEmployeeRepository repository, ApplicationDbContext context)
        {
            _context = context;
            repo = repository;

        }

        [HttpGet]
        [Route("GetAllEmployee")]
        public async Task<IActionResult> GetAllEmployee()
        {
            var user = await repo.GetAllUsers();
            return Ok(user);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUserId([FromRoute] Guid id)
        {
            var user = await repo.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Success()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Store(EmployeeViewModel employeeViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var user = await repo.CreateEmployee(employeeViewModel);
                TempData["SuccessMessage"] = "Employee successfully registered";
                return RedirectToAction(nameof(Success)); // Redirect to the Index action or another action
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is MySqlException e && (e.Number == 1062))
                {
                    if (e.Message.Contains("Email") && e.Message.Contains("Phone"))
                    {
                        return BadRequest("Email and Phone Number already exists");
                    }
                    else if (e.Message.Contains("Email"))
                    {
                        return BadRequest("Email already exists");
                    }
                    return BadRequest("Phone Number already exist");
                }
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            var templogin = _context.Employees.FirstOrDefault(x => x.Email == login.Email && x.Password == login.Password);
            if (templogin == null)
            {
                TempData["ErrorMessage"] = "Invalid login details. Please try again.";
                return View("Login");
            }
            return View("~/Views/LeaveRequest/Create.cshtml");

        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id, [FromBody] EmployeeViewModel employeeViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await repo.CreateEmployee(employeeViewModel);
                return Ok(employeeViewModel);
            }

            catch (DbUpdateException ex)
            {
                if (ex.InnerException is MySqlException e && (e.Number == 1062))
                {
                    if (e.Message.Contains("Email"))
                    {
                        return BadRequest("Email already exists");
                    }
                    return BadRequest("Phone Number already exist");
                }
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("remove/{id}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {
            var user = await repo.DeleteEmployee(id);
            return Ok(user);
        }







    }
}
