using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Project.BL.Profiles;
using Project.BL.Services.Abstractions;
using Project.BL.Services.Implementations;
using Project.BL.Validations;
using Project.DAL.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Extensions
{
    public static class ServiceExtensionForBL
    {
        public static void AddingServiceForBL(this IServiceCollection service)
        {
            service.AddScoped<IAuthService, AuthService>();
            service.AddScoped<ICategoryService, CategoryService>();
            service.AddScoped<ITravelService, TravelService>();

            service.AddAutoMapper(typeof(AuthProfile).Assembly);
            service.AddAutoMapper(typeof(CategoryProfile).Assembly);
            service.AddAutoMapper(typeof(TravelProfile).Assembly);

            service.AddValidatorsFromAssembly(typeof(AuthValidation).Assembly);
            service.AddValidatorsFromAssembly(typeof(CategoryValidation).Assembly);
            service.AddValidatorsFromAssembly(typeof(TravelValidation).Assembly);
            service.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

        }
    }
}
