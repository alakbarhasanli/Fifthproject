using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Project.BL.Profiles;
using Project.BL.Services.Abstractions;
using Project.BL.Services.Implementations;
using Project.BL.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL
{
    public static class ServiceExtensionBL
    {
        public static void AddServiceBL(this IServiceCollection service)
        { 
            service.AddScoped<IAuthService, AuthService>();
            service.AddScoped<ICategoryService, CategoryService>();
            service.AddScoped<IDoctorService, DoctorService>();

            service.AddAutoMapper(typeof(AuthProfile).Assembly);
            service.AddAutoMapper(typeof(DoctorProfile).Assembly);
            service.AddAutoMapper(typeof(CategoryProfile).Assembly);

            service.AddValidatorsFromAssembly(typeof(RegisterValidation).Assembly);
            service.AddValidatorsFromAssembly(typeof(LoginValidation).Assembly);
            service.AddValidatorsFromAssembly(typeof(DoctorValidation).Assembly);
            service.AddValidatorsFromAssembly(typeof(CategoryValidation).Assembly);
            service.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

        }



    }
}

