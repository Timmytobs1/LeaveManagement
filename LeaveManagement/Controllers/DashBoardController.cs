using Microsoft.AspNetCore.Mvc;

namespace LeaveManagement.Controllers
{
    public class DashBoardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
