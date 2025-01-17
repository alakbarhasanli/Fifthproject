using Microsoft.EntityFrameworkCore;
using Project.DAL.Contexts;
using Project.DAL.Entities;
using Project.DAL.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new()
    {
        private readonly FifthDbContext _context;

        public GenericRepository(FifthDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task CreateAsync(T entity)
        {
           await Table.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            Table.Remove(entity);
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            return await Table.ToListAsync();
        }

        public async Task<T> GetOneByIdAsync(int id)
        {
            T? entity = await Table.FirstOrDefaultAsync(e => e.Id == id);
            if (entity == null) 
            {
                throw new Exception("entity not found");
            }
            _context.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public async Task<int> SaveChangesAsync()
        {
            int rows = await _context.SaveChangesAsync();
            return rows;
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            
        }
    }
}
