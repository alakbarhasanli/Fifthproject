using Microsoft.AspNetCore.Mvc;

namespace SeventProject.PL.Areas.admin.Controllers
{
    [Area("admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
