using FluentValidation;
using Microsoft.Identity.Client;
using Project.BL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Project.BL.Validations
{
    public class AuthValidation:AbstractValidator<RegisterAuthDto>
    {
        public AuthValidation()
        {
            RuleFor(t => t.Firstname).NotNull().NotEmpty().WithMessage("Required Firstname").MinimumLength(3).WithMessage("must be 3 chars");
            RuleFor(t => t.Lastname).NotNull().NotEmpty().WithMessage("Required Lastname").MinimumLength(3).WithMessage("must be 3 chars");
            RuleFor(t => t.Username).NotNull().NotEmpty().WithMessage("Required Username").MinimumLength(3).WithMessage("must be 3 chars");
            RuleFor(t => t.Password).NotNull().NotEmpty().WithMessage("Required Password").Equal(p => p.ConfirmPassword).WithMessage("Doesnt match Password");
            RuleFor(t => t.ConfirmPassword).NotNull().NotEmpty().WithMessage("Required Repeat Password");


        }
    }
}
