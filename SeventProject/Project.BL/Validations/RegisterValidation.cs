using FluentValidation;
using Project.BL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Validations
{
    public class RegisterValidation:AbstractValidator<RegisterCreateDto>
    {
        public RegisterValidation()
        {
            RuleFor(c => c.UserName).NotEmpty().NotNull().WithMessage("Required Username").MinimumLength(3).WithMessage("Must be at least 3 chars");
            RuleFor(c => c.Email).NotEmpty().NotNull().WithMessage("Required Email").EmailAddress().WithMessage("Wrong Email Format");
            RuleFor(c => c.Password).NotEmpty().NotNull().WithMessage("Required Password").MinimumLength(3).WithMessage("Must be at least 3 chars");
            RuleFor(c => c.ConfirmPassword).NotEmpty().NotNull().WithMessage("Repeat Password").Equal(p => p.Password).WithMessage("Doesnt Match");
        }
    }
}
