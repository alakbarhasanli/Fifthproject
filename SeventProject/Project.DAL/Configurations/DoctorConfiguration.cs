using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Configurations
{
	public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
	{
		public void Configure(EntityTypeBuilder<Doctor> builder)
		{
			builder
			.Property(e => e.Name)
			.HasMaxLength(29)
			.IsRequired();
			builder
			.Property(e => e.Department)
			.HasMaxLength(29)
			.IsRequired();
		}
	}
}
