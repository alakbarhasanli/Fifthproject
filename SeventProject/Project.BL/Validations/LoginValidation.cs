using FluentValidation;
using Project.BL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Validations
{
    public class LoginValidation:AbstractValidator<LoginCreateDto>
    {
        public LoginValidation()
        {
            RuleFor(c => c.UserName).NotEmpty().NotNull().WithMessage("Required Username");
            RuleFor(c => c.Password).NotEmpty().NotNull().WithMessage("Required Password");
        }
    }
}
