

using Microsoft.AspNetCore.Mvc;
using Project.BL.Services.Abstractions;

namespace FifthProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITravelService _service;
public HomeController(ITravelService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allTravels = await _service.GetAllAsync();
            return View(allTravels);
        }

       

       
    }
}
