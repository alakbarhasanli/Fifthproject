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
        public Task RegisterAsync(RegisterCreateDto dto);
        public Task LoginAsync(LoginCreateDto dto);
        public Task LogoutAsync();
    }
}
