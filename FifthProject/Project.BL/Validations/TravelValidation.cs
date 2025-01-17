using FluentValidation;
using Project.BL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Validations
{
    public class TravelValidation:AbstractValidator<TravelCreateDto>
    {
        public TravelValidation()
        {
            RuleFor(t => t.Title).NotNull().NotEmpty().WithMessage("Required Title").MinimumLength(3).WithMessage("must be 3 chars");
            RuleFor(t => t.Description).NotNull().NotEmpty().WithMessage("Required Description").MinimumLength(3).WithMessage("must be 3 chars");
            RuleFor(t => t.MinimumPrice).NotNull().NotEmpty().WithMessage("Required Minimum price").GreaterThan(0).WithMessage("Price Must be 1$");
            RuleFor(c => c.MaximumPrice).NotNull().NotEmpty().WithMessage("Required Maximum price").GreaterThan(t => t.MinimumPrice).WithMessage("Price Must be hiigh than Minimum Price");
            RuleFor(t => t.Rating).NotNull().NotEmpty().WithMessage("Required rating").InclusiveBetween(0, 5).WithMessage("Rating Must be between 0-5");
            RuleFor(t => t.RatingCount).NotNull().NotEmpty().WithMessage("Required rating count").GreaterThan(-1).WithMessage("Rating Count Must be 0");
            RuleFor(t => t.CategoryId).NotNull().NotEmpty().WithMessage("Required CategoryId");
            RuleFor(t => t.TravelPhoto).NotNull().NotEmpty().WithMessage("Required Photo");

        }
    }
}
