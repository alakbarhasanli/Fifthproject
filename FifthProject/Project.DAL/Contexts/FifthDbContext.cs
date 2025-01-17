using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Contexts
{
    public class FifthDbContext:IdentityDbContext<AppUser>
    {
        public DbSet<Category> categories { get; set; }
        public DbSet<Travel> travels { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); 
        }
        public FifthDbContext(DbContextOptions opt):base(opt)
        {
            
        }
      
    }
}
