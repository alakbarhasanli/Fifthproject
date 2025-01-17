using Project.BL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Services.Abstractions
{
    public interface IAuthService
    {
        Task<bool> RegisterAsync(RegisterAuthDto registerAuthDto);
        Task<bool> LoginAsync(LoginAuthDto loginAuthDto);
        Task<bool> LogoutAsync();
    }
}
