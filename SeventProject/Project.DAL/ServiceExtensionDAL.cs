using Microsoft.Extensions.DependencyInjection;
using Project.DAL.Entities;
using Project.DAL.Repositories.Abstractions;
using Project.DAL.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL
{
    public static class ServiceExtensionDAL
    {
        public static void AddServiceDAL(this IServiceCollection service)
        {
            service.AddScoped<IGenericRepository<Doctor>, GenericRepository<Doctor>>();
            service.AddScoped<IGenericRepository<Category>, GenericRepository<Category>>();
        }



    }
}
