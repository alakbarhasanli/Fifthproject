using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Project.BL.DTOs;
using Project.BL.Helpers;
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
    public class TravelService : ITravelService
    {
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        private readonly ITravelRepository _repo;

        public TravelService(IMapper? mapper, IWebHostEnvironment env, ITravelRepository repo)
        {
            _mapper = mapper;
            _env = env;
            _repo = repo;
        }

        public async Task CreateAsync(TravelCreateDto travelCreateDto)
        {
            Travel? travel = _mapper.Map<Travel>(travelCreateDto);
            if (travel == null)
            {
                throw new Exception(" Travel Not Found");

            }
            if(travelCreateDto.TravelPhoto!=null)
            {
                string webpath = _env.WebRootPath;
                string filename = await  travelCreateDto.TravelPhoto.ImageUpload(Path.Combine(webpath, "Upload", "Images"));
                travel.ImageUrl = filename;
            }
            await _repo.CreateAsync(travel);
            await _repo.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var travel = await _repo.GetOneByIdAsync(id);
            if (travel == null)
            {
                throw new Exception("Travel Not Found");

            }
            _repo.Delete(travel);
            await _repo.SaveChangesAsync();
            return true;
        }

        public async Task<ICollection<Travel>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<Travel> GetOneByIdAsync(int id)
        {
            var oneTravel = await _repo.GetOneByIdAsync(id);
            if (oneTravel == null)
            {
                throw new Exception("Travel Not Found");

            }
            return oneTravel;
        }

        public async Task<bool> UpdateAsync(TravelCreateDto travelCreateDto, int id)
        {
            Travel? travel = _mapper.Map<Travel>(travelCreateDto);
            travel.Id = id;
            var oneTravel = await _repo.GetOneByIdAsync(id);
            if (oneTravel == null)
            {
                throw new Exception("Travel Not Found");

            }
            if (travel == null)
            {
                throw new Exception(" Travel Not Found");

            }
            if (travel.TravelPhoto != null)
            {
                string webpath = _env.WebRootPath;
                string filename = await travel.TravelPhoto.ImageUpload(Path.Combine(webpath, "Upload", "Images"));
                travel.ImageUrl = filename;
            }
            
            _repo.Update(travel);
            await _repo.SaveChangesAsync();
            return true;
        }
    }
}
