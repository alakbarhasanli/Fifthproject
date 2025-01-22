using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BL.DTOs;
using Project.BL.Services.Abstractions;
using Project.DAL.Enums;
using Project.DAL.Exceptions;

namespace SeventProject.PL.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = ("admin"))]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allCategory = await _service.GetAllAsync();
            return View(allCategory);
        }
        public async Task<IActionResult> Info(int id)
        {
            try
            {
                var oneCategory = await _service.GetOneByIdAsync(id);
                return View(oneCategory);

            }
            catch (BaseException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest("Category with this id Not Found");
            }
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateDto dto)
        {
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
                ModelState.AddModelError("CustomError",ex.Message);
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
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(CategoryCreateDto dto,int id)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            try
            {
                await _service.UpdateAsync(dto,id);
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
                return BadRequest("Category with this id Not Found");
            }
            return RedirectToAction("Index");
        }

    }
}
