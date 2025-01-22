using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Project.BL.DTOs;
using Project.BL.Helpers;
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
    public class DoctorService : IDoctorService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Doctor> _repo;
        private readonly IWebHostEnvironment _env;

        public DoctorService(IMapper mapper, IGenericRepository<Doctor> repo, IWebHostEnvironment env)
        {
            _mapper = mapper;
            _repo = repo;
            _env = env;
        }

        public async Task<ICollection<Doctor>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<Doctor> GetOneByIdAsync(int id)
        {
            var oneDoctor = await _repo.GetOneAsync(id);
            return oneDoctor;
        }
        public async Task CretaeAsync(DoctorCreateDto dto)
        {
            Doctor? doctor = _mapper.Map<Doctor>(dto) ?? throw new BaseException("Doctor not Found");
            doctor.CreatedAt = DateTime.Now;
            if(doctor.Photo!=null)
            {
                string rootPath = _env.WebRootPath;
                string filename = await  doctor.Photo.ImageUpload(Path.Combine(rootPath, "Uploads", "Images"));
                doctor.ImageUrl = filename;
            }
            await _repo.CreateAsync(doctor); 
            await _repo.SaveChangesAsync();

        }

        public async Task UpdateAsync(DoctorCreateDto dto, int id)
        {
            var oldDoctor = await _repo.GetOneAsync(id) ?? throw new BaseException("Doctor Not Found");
            Doctor? doctor = _mapper.Map<Doctor>(dto) ?? throw new BaseException("Doctor not Found");
            doctor.Id = id;
            doctor.UpdatedAt = DateTime.Now;
            if (doctor.Photo != null)
            {
                string rootPath = _env.WebRootPath;
                string filename = await doctor.Photo.ImageUpload(Path.Combine(rootPath, "Uploads", "Images"));
                doctor.ImageUrl = filename;
            }
            _repo.Update(doctor);
            await _repo.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var doctor = await _repo.GetOneAsync(id) ?? throw new BaseException("Doctor Not Found");
            _repo.Delete(doctor);
            await _repo.SaveChangesAsync();
        }


    }
}
