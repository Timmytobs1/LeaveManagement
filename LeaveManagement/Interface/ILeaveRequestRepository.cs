using LeaveManagement.Models;
using LeaveManagement.Models.Entities;

namespace LeaveManagement.Interface
{
    public interface ILeaveRequestRepository
    {

        public Task<List<LeaveRequest>> GetAll();
        public Task<LeaveRequest> GetById(int id);
        public Task<LeaveRequest> Create (LeaveRequestViewModel leaveRequestViewModel);
        public Task<LeaveRequest> Add(LeaveRequestViewModel leaveRequestViewModel);
        public Task<LeaveRequest> Update(LeaveRequestViewModel leaveRequestViewModel);
        public Task<LeaveRequest> Delete(int id);
    }
}
