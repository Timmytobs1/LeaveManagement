using LeaveManagement.Interface;
using LeaveManagement.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FluentEmail.Core;
using LeaveManagement.Models;
using LeaveManagement.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
//  NETCore.MailKit.Core. 

namespace LeaveManagement.Controllers
{
    //[Authorize]
    public class LeaveRequestController : Controller
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ApplicationDbContext _context;

        public LeaveRequestController(ILeaveRequestRepository leaveRequestRepository, ApplicationDbContext context)
        {
            _context = context;
            _leaveRequestRepository = leaveRequestRepository;
   
        }

        //[Authorize(Roles = "Employee, Approver")]
        public async Task<IActionResult> Index()
        {
            var leaveRequests = await _leaveRequestRepository.GetAll();
            return View();
        }

        //[Authorize(Roles = "Employee")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //[Authorize(Roles = "Employee")]
        public async Task<IActionResult> Create(LeaveRequestViewModel leaveRequestViewModel)
        {
                try {
                    var user = await _context.Employees.FirstOrDefaultAsync(c=>c.Id == leaveRequestViewModel.EmployeeId);
                    var leaveRequest = new LeaveRequest
                {
                    EmployeeId = user.Id, // Assuming EmployeeId is correctly bound in the form
                    StartDate = leaveRequestViewModel.StartDate,
                    EndDate = leaveRequestViewModel.EndDate,
                    LeaveType = leaveRequestViewModel.LeaveType,
                    Reason = leaveRequestViewModel.Reason,
                    Status = "Pending"
                };
                    await _context.AddAsync(leaveRequest);
                await _context.SaveChangesAsync();
/*                    await _leaveRequestRepository.Add(leaveRequestViewModel);*/
                    return View("successs");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Failed to create leave request. Please try again.");
                    // Log the exception if necessary
                    return View(leaveRequestViewModel); // Return the view with validation errors
                }
            
        }


        //        [Authorize(Roles = "Approver")]
        public async Task<IActionResult> Approve(int id)
        {
            var leaveRequest = await _leaveRequestRepository.GetById(id);
            if (leaveRequest == null)
            {
                return NotFound();
            }
            leaveRequest.Status = "Approved";
           // await _leaveRequestRepository.Update(leaveRequest);

            return RedirectToAction(nameof(Index));
        }

       // [Authorize(Roles = "Approver")]
        public async Task<IActionResult> Reject(int id)
        {
            var leaveRequest = await _leaveRequestRepository.GetById(id);
            if (leaveRequest == null)
            {
                return NotFound();
            }
            leaveRequest.Status = "Rejected";
       

            return RedirectToAction(nameof(Index));
        }
    }
}
