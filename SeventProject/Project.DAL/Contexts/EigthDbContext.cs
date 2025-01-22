using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Contexts
{
	public class EigthDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
	{
        public DbSet<Category> categories { get; set; }
        public DbSet<Doctor> doctors { get; set; }
        public EigthDbContext(DbContextOptions opt) : base(opt)
		{

		}
		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
			builder.Entity<IdentityRole>().HasData(
				new IdentityRole { Id = "a85cec89-2ca8-40c4-b62b-286e65d1d768", Name = "admin", NormalizedName = "ADMIN" },
				new IdentityRole { Id = "9a4b4262-f6bb-437e-a8cf-6fb770af2175", Name = "user", NormalizedName = "User" }

			);
			IdentityUser admin = new()
			{
				Id = "cf21cebc-4bf2-4597-bdd8-b31c884837da",
				UserName = "adminus",
				NormalizedUserName = "ADMINUS"

			};
			PasswordHasher<IdentityUser> hash = new();
			admin.PasswordHash = hash.HashPassword(admin, "admin123!");
			builder.Entity<IdentityUser>().HasData(admin);
			builder.Entity<IdentityUserRole<string>>().HasData(
				new IdentityUserRole<string> { UserId=admin.Id,RoleId= "a85cec89-2ca8-40c4-b62b-286e65d1d768" }
				);



			base.OnModelCreating(builder);
		}
	}
}
