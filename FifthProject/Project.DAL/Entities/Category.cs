using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entities
{
    public class Category:BaseEntity
    {
        [Required]
        [Display(Prompt ="Title")]
        public string Title { get; set; }
        public ICollection<Travel> travels { get; set; }
    }
}
