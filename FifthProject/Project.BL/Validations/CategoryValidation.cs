using FluentValidation;
using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Validations
{
    public class CategoryValidation:AbstractValidator<Category>
    {
        public CategoryValidation()
        {
            RuleFor(c => c.Title).NotNull().NotEmpty().WithMessage("Required Title").MinimumLength(3).WithMessage("must be 3 chars");
        }
    }
}
