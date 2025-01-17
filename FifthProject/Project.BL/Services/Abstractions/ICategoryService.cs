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
        Task<ICollection<Category>> GetAllAsync();
        Task <Category> GetOneByIdAsync(int id);
        Task CreateAsync(CategoryCreateDto categoryCreateDto);
        Task<bool> UpdateAsync(CategoryCreateDto categoryCreateDto, int id);
        Task<bool> DeleteAsync (int id);


    }
}
