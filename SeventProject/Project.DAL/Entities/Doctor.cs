using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entities
{
	public class Doctor : BaseEntitiy
	{
		public string Name { get; set; }
		public string Department { get; set; }
		public string? ImageUrl { get; set; }
		public int CategoryId { get; set; }
		[NotMapped]
        public IFormFile? Photo { get; set; }
        public Category category { get; set; }
    }
}
