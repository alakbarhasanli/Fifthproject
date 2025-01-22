using FluentValidation;
using Project.BL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Validations
{
    public class DoctorValidation:AbstractValidator<DoctorCreateDto>
    {
        public DoctorValidation()
        {
            RuleFor(c => c.Name).NotEmpty().NotNull().WithMessage("Required Name").MinimumLength(3).WithMessage("Must be at least 3 chars");
            RuleFor(c => c.Department).NotEmpty().NotNull().WithMessage("Required Department").MinimumLength(3).WithMessage("Must be at least 3 chars");
            RuleFor(c => c.CategoryId).NotEmpty().NotNull().WithMessage("Required Category");
            RuleFor(c => c.Photo).NotEmpty().NotNull().WithMessage("Required Photo");
            

        }
    }
}
