using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.DTOs
{
    public class RegisterCreateDto
    {
        [Display(Prompt = "Username")]
        [Required]
        public string UserName { get; set; }
        [Display(Prompt = "Email")]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }
        [Display(Prompt = "Username")]
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        [Display(Prompt = "Confirm Password")]
        [DataType(DataType.Password)]
        [Required]
        public string ConfirmPassword { get; set; }
    }
}
