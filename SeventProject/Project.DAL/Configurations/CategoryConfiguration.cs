using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Configurations
{
	public class CategoryConfiguration : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
	
	builder
		.HasMany(e => e.doctors)
		.WithOne(e => e.category)
		.HasForeignKey(e => e.CategoryId)
		.OnDelete(DeleteBehavior.Cascade)
		.IsRequired();

			builder
			.Property(e => e.Title)
			.HasMaxLength(29)
			.IsRequired();
		}
	
	}
}
