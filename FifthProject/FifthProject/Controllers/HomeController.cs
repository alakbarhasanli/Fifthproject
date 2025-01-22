

using FifthProject.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Project.BL.Services.Abstractions;

namespace FifthProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITravelService _service;
		private readonly ICategoryService _categoryservice;
		public HomeController(ITravelService service, ICategoryService categoryservice)
		{
			_service = service;
			_categoryservice = categoryservice;
		}

		public async Task<IActionResult> Index()
        {
            HomeVm vm = new()
            {
                travels = await _service.GetAllAsync(),
                categories = await _categoryservice.GetAllAsync()
            };

            return View(vm);
        }

       

       
    }
}
