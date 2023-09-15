using Microsoft.AspNetCore.Mvc;

namespace FinanceTrackingApp.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
