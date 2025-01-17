using Microsoft.AspNetCore.Mvc;
using Project.BL.DTOs;
using Project.BL.Services.Abstractions;
using System.Security.Cryptography.Xml;

namespace FifthProject.Areas.admin.Controllers
{
    [Area("admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _service;
        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allCategories = await _service.GetAllAsync();
            return View(allCategories);
        }
        public async Task<IActionResult> Info(int id)
        {
            var oneCategory = await _service.GetOneByIdAsync(id);
            if (oneCategory == null)
            {
                throw new Exception("Category Not Found");
            }
            return View(oneCategory);
        }
        public async Task<IActionResult> Create(CategoryCreateDto categoryCreateDto)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateAsync(categoryCreateDto);
                return RedirectToAction("Index");
            }
            return View(categoryCreateDto);
        }
        public async Task<IActionResult> Update(CategoryCreateDto categoryCreateDto, int id)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(categoryCreateDto, id);
               
                return RedirectToAction("Index");
            }
            return View(categoryCreateDto);
        }
        public async Task<IActionResult> Delete(int id)
        {

           await _service.DeleteAsync(id);
            

            return View("Index");
        }

    }
}
