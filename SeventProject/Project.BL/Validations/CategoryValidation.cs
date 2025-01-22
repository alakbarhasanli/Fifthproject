using FluentValidation;
using Project.BL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Validations
{
    public class CategoryValidation:AbstractValidator<CategoryCreateDto>
    {
        public CategoryValidation()
        {
            RuleFor(c => c.Title).NotEmpty().NotNull().WithMessage("Required Title").MinimumLength(3).WithMessage("Must be at least 3 chars");
        }
    }
}
