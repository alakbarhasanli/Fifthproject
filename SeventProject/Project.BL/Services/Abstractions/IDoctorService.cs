using Project.BL.DTOs;
using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Services.Abstractions
{
    public interface IDoctorService
    {
        public Task<ICollection<Doctor>> GetAllAsync();
        public Task<Doctor> GetOneByIdAsync(int id);
        public Task CretaeAsync(DoctorCreateDto dto);
        public Task UpdateAsync(DoctorCreateDto dto, int id);
        public Task DeleteAsync(int id);
    }
}
