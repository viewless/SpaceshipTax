using FluentValidation;
using SpaceshipTax.Models.Models;

namespace SpaceshipTax.Models.RequestModels
{
    public class SpaceshipValidator : AbstractValidator<SpaceshipModel> 
    {
        public SpaceshipValidator()
        {
            RuleFor(spaceship => spaceship.CurrentYear)
                .NotNull().WithMessage("Number is required")
                .GreaterThan(0).WithMessage("Current year must be greater than 0")
                .GreaterThan(x => x.BoughtYear).WithMessage("Current year must be greater than bought year");

            RuleFor(spaceship => spaceship.BoughtYear)
                .NotNull().WithMessage("Number is required")
                .GreaterThan(0).WithMessage("Bought year must be greater than 0")
                .LessThan(x => x.CurrentYear).WithMessage("Bought year must be lesser than current year");

            RuleFor(spaceship => spaceship.DistanceTravelled)
                .NotNull().WithMessage("Number is required")
                .GreaterThan(0).WithMessage("Distance travelled must be greater than 0");
        }
    }
}
