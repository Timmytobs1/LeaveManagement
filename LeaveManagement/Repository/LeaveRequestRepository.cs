using LeaveManagement.Data;
using LeaveManagement.Interface;
using LeaveManagement.Models;
using LeaveManagement.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Repository
{
    public class LeaveRequestRepository : ILeaveRequestRepository
    {
        private readonly ApplicationDbContext _context;

        public LeaveRequestRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<LeaveRequest>> GetAll()
        {
            return await _context.LeaveRequests.ToListAsync();
        }

        public async Task<LeaveRequest> GetById(int id)
        {
            return await _context.LeaveRequests.FindAsync(id);
        }

        public async Task<LeaveRequest> Add(LeaveRequest leaveRequest)
        {
            await _context.LeaveRequests.AddAsync(leaveRequest);
            await _context.SaveChangesAsync();
            return leaveRequest;
        }

        public async Task<LeaveRequest> Update(LeaveRequest leaveRequest)
        {
            _context.LeaveRequests.Update(leaveRequest);
            await _context.SaveChangesAsync();
            return leaveRequest;

        }

        public async Task<LeaveRequest> Delete(int id)
        {
            var leaveRequest = await _context.LeaveRequests.FindAsync(id);
            if (leaveRequest != null)
            {
                _context.LeaveRequests.Remove(leaveRequest);
                await _context.SaveChangesAsync();
            }
            return leaveRequest;
        }

    
        public Task<LeaveRequest> Create(LeaveRequestViewModel leaveRequestViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<LeaveRequest> Add(LeaveRequestViewModel leaveRequestViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<LeaveRequest> Update(LeaveRequestViewModel leaveRequestViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
