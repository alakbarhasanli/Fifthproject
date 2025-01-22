using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Project.BL.DTOs;
using Project.BL.Services.Abstractions;
using Project.DAL.Entities;
using Project.DAL.Exceptions;
using Project.DAL.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Services.Implementations
{
    public class CategoryService:ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Category> _repo;

        public CategoryService(IMapper mapper, IGenericRepository<Category> repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<ICollection<Category>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<Category> GetOneByIdAsync(int id)
        {
            var oneCategory = await _repo.GetOneAsync(id)?? throw new BaseException("Category not Found");
            return oneCategory;
        }
        public async Task CretaeAsync(CategoryCreateDto dto)
        {
            Category? category = _mapper.Map<Category>(dto) ?? throw new BaseException("Category not Found");
            category.CreatedAt = DateTime.Now;
           
            await _repo.CreateAsync(category);
            await _repo.SaveChangesAsync();

        }

        public async Task UpdateAsync(CategoryCreateDto dto, int id)
        {
            var oldCategory = await _repo.GetOneAsync(id) ?? throw new BaseException("Category Not Found");
            Category? category = _mapper.Map<Category>(dto) ?? throw new BaseException("Category not Found");
            category.Id = id;
            category.UpdatedAt = DateTime.Now;
           
            _repo.Update(category);
            await _repo.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var category = await _repo.GetOneAsync(id) ?? throw new BaseException("Category Not Found");
            _repo.Delete(category);
            await _repo.SaveChangesAsync();
        }
    }
}
