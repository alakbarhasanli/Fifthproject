using Project.BL.DTOs;
using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Services.Abstractions
{
    public interface ICategoryService
    {
        public Task<ICollection<Category>> GetAllAsync();
        public Task<Category> GetOneByIdAsync(int id);
       public Task CretaeAsync(CategoryCreateDto dto);
        public Task UpdateAsync(CategoryCreateDto dto, int id);
        public Task DeleteAsync(int id);
    }
}
