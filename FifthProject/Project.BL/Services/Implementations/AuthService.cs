using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Update;
using Project.BL.DTOs;
using Project.BL.Services.Abstractions;
using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly SignInManager<AppUser> _sign;
        private readonly UserManager<AppUser> _user;
        private readonly RoleManager<IdentityRole> _role;
        public AuthService(IMapper mapper, SignInManager<AppUser> sign, UserManager<AppUser> user, RoleManager<IdentityRole> role)
        {
            _mapper = mapper;
            _sign = sign;
            _user = user;
            _role = role;
        }

        public async Task<bool> LoginAsync(LoginAuthDto loginAuthDto)
        {
            AppUser? user = await _user.FindByNameAsync(loginAuthDto.Username);
            if(user==null)
            {
                throw new Exception("user not found");
            }
            var result = await _sign.PasswordSignInAsync(user, loginAuthDto.Password, loginAuthDto.IsPersistent = true, true);
            if(!result.Succeeded)
            {
                throw new Exception("Dont login");
            }
            return true;

        }

        public async Task<bool> LogoutAsync()
        {
            await _sign.SignOutAsync();
            return true;
        }

        public async Task<bool> RegisterAsync(RegisterAuthDto registerAuthDto)
        {
            AppUser? user = _mapper.Map<AppUser>(registerAuthDto);
            if (user == null)
            {
                throw new Exception("user not found");
            }
            await _role.CreateAsync(new IdentityRole("admin"));
            await _role.CreateAsync(new IdentityRole("user"));
            await _role.CreateAsync(new IdentityRole("manager"));
            var result = await _user.CreateAsync(user,registerAuthDto.Password);
            if (!result.Succeeded)
            {
                throw new Exception("Dont Create Account");
            }
            await _user.AddToRoleAsync(user, "admin");

            return true;

        }
    }
}
