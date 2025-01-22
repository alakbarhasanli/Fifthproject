using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.BL.DTOs;
using Project.BL.Services.Abstractions;
using Project.DAL.Exceptions;

namespace SeventProject.PL.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _service;
        public AuthController(IAuthService service)
        {
            _service = service;
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterCreateDto dto)
        {

            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            try
            {
                await _service.RegisterAsync(dto);
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
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginCreateDto dto)
        {

            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            try
            {
                await _service.LoginAsync(dto);
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
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Logout()
        {
            try
            {
                await _service.LogoutAsync();

            }
            catch (BaseException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest(" Something went wrong");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
