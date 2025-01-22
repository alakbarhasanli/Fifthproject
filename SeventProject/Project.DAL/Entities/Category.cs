using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entities
{
	public class Category:BaseEntitiy
	{
        public string Title { get; set; }
		public ICollection<Doctor> doctors { get; set; }
    }
}
