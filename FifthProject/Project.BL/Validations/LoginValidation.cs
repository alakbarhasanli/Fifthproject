using FluentValidation;
using Project.BL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Validations
{
    public class LoginValidation:AbstractValidator<LoginAuthDto>
    {
        public LoginValidation()
        {
            RuleFor(t => t.Username).NotNull().NotEmpty().WithMessage("Required Username");
            RuleFor(t => t.Password).NotNull().NotEmpty().WithMessage("Required Password");
        }
    }
}
