using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Project.BL.DTOs;
using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Profiles
{
    public class AuthProfile:Profile
    {
        public AuthProfile()
        {
            CreateMap<IdentityUser, RegisterCreateDto>().ReverseMap();
            CreateMap<IdentityUser, LoginCreateDto>().ReverseMap();
        }
    }
}
