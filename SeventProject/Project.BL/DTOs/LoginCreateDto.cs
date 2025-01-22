using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.DTOs
{
    public class LoginCreateDto
    {
        [Display(Prompt = "Username")]
        [Required]
        public string UserName { get; set; }
        [Display(Prompt = "Username")]
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        public bool IsPersistent { get; set; }
    }
}
