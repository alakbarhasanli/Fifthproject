using Project.BL.DTOs;
using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Services.Abstractions
{
    public interface ITravelService
    {
        Task<ICollection<Travel>> GetAllAsync();
        Task<Travel> GetOneByIdAsync(int id);
        Task CreateAsync(TravelCreateDto travelCreateDto);
        Task<bool> UpdateAsync(TravelCreateDto travelCreateDto, int id);
        Task<bool> DeleteAsync( int id);
    }
}
