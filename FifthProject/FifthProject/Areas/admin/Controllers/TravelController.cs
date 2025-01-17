using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BL.DTOs;
using Project.BL.Services.Abstractions;
using Project.DAL.Contexts;

namespace FifthProject.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles ="admin")]
    public class TravelController : Controller
    {
        private readonly ITravelService _service;
        private readonly FifthDbContext _context;
        public TravelController(ITravelService service, FifthDbContext context)
        {
            _service = service;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allTravels = await _service.GetAllAsync();
            return View(allTravels);
        }
        public async Task<IActionResult> Info(int id)
        {
            var oneTravel = await _service.GetOneByIdAsync(id);
            if (oneTravel == null)
            {
                throw new Exception("Travel Not Found");
            }
            return View(oneTravel);
        }


        public IActionResult Create()
        {
            ViewBag.Category = _context.categories;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TravelCreateDto travelCreateDto)
        {
            ViewBag.Category = _context.categories;
            if (ModelState.IsValid)
            {
                await _service.CreateAsync(travelCreateDto);
                return RedirectToAction("Index");
            }
            return View(travelCreateDto);
        }
        public async Task<IActionResult> Update(TravelCreateDto travelCreateDto, int id)
        {
            ViewBag.Category = _context.categories;
            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(travelCreateDto, id);
                
                return RedirectToAction("Index");
            }
            return View(travelCreateDto);
        }
        public async Task<IActionResult> Delete(int id)
        {
            ViewBag.Category = _context.categories;

           await _service.DeleteAsync(id);
            

            return View("Index");
        }
    }
}
