using AutoMapper;
using Project.BL.DTOs;
using Project.BL.Services.Abstractions;
using Project.DAL.Entities;
using Project.DAL.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _repo;


        public CategoryService(IMapper mapper, ICategoryRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task CreateAsync(CategoryCreateDto categoryCreateDto)
        {
            Category? category = _mapper.Map<Category>(categoryCreateDto);
            if (category == null)
            {
                throw new Exception("Category Not Found");

            }
            await _repo.CreateAsync(category);
            await _repo.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _repo.GetOneByIdAsync(id);
            if (category == null)
            {
                throw new Exception("Category Not Found");

            }
            _repo.Delete(category);
            await _repo.SaveChangesAsync();
            return true;
        }

        public async Task<ICollection<Category>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<Category> GetOneByIdAsync(int id)
        {
            var oneCategory = await _repo.GetOneByIdAsync(id);
            if(oneCategory==null)
            {
                throw new Exception("Category Not Found");

            }
            return oneCategory;
        }

        public async Task<bool> UpdateAsync(CategoryCreateDto categoryCreateDto, int id)
        {
            Category? category = _mapper.Map<Category>(categoryCreateDto);
            if (category == null)
            {
                throw new Exception("Category Not Found");

            }
            
            var oneCategory = await _repo.GetOneByIdAsync(id);
            if (oneCategory == null)
            {
                throw new Exception("Category Not Found");

            }
            category.Id = id;
            _repo.Update(category);
            await _repo.SaveChangesAsync();
            return true;
        }
    }
}
