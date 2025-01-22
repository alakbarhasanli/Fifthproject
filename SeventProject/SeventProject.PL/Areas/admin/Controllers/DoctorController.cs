using Microsoft.AspNetCore.Mvc;
using Project.BL.DTOs;
using Project.BL.Services.Abstractions;
using Project.DAL.Contexts;
using Project.DAL.Exceptions;

namespace SeventProject.PL.Areas.admin.Controllers
{
    [Area("admin")]
    public class DoctorController : Controller
    {
        private readonly IDoctorService _service;
        private readonly EigthDbContext _context;

        public DoctorController(IDoctorService service, EigthDbContext context)
        {
            _service = service;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var allDoctor = await _service.GetAllAsync();
            return View(allDoctor);
        }
        public async Task<IActionResult> Info(int id)
        {
            try
            {
                var oneDoctor = await _service.GetOneByIdAsync(id);
                return View(oneDoctor);

            }
            catch (BaseException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest("Docotr with this id Not Found");
            }
        }
        public IActionResult Create()
        {
            ViewBag.Category = _context.categories;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(DoctorCreateDto dto)
        {
            ViewBag.Category = _context.categories;
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            try
            {
                await _service.CretaeAsync(dto);
            }
            catch (BaseException ex)
            {
                ModelState.AddModelError("CustomError", ex.Message);
                return View(dto);
            }
            catch (Exception)
            {
                ModelState.AddModelError("CustomError", "Something Went Wrong");
                return View(dto);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Update()
        {
            ViewBag.Category = _context.categories;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(DoctorCreateDto dto, int id)
        {
            ViewBag.Category = _context.categories;
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            try
            {
                await _service.UpdateAsync(dto, id);
            }
            catch (BaseException ex)
            {
                ModelState.AddModelError("CustomError", ex.Message);
                return View(dto);
            }
            catch (Exception)
            {
                ModelState.AddModelError("CustomError", "Something Went Wrong");
                return View(dto);
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteAsync(id);

            }
            catch (BaseException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest("Doctor with this id Not Found");
            }
            return RedirectToAction("Index");
        }
    }
}
