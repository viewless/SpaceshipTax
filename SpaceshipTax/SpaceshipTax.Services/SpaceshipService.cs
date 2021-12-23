using FluentValidation;
using SpaceshipTax.Models.Models;
namespace SpaceshipTax.Services
{
    public class SpaceshipService : ISpaceshipService
    {
        public int CalculateTax(SpaceshipModel spaceship, string spaceshipType)
        {
            var result = 0;

            if (spaceship == null)
            {
               
                throw new ValidationException($"The spaceship doens't exist");
            }

            if (spaceshipType == "family")
            {
                var increase = spaceship.DistanceTravelled / Constants.Constants.MilesConsumption;

                var decrease = spaceship.CurrentYear - spaceship.BoughtYear;

                result = Constants.Constants.FamilyInitialTax + increase * Constants.Constants.FamilyTaxIncrease - decrease * Constants.Constants.FamilyTaxDecrese;

            }
            else if (spaceshipType == "cargo")
            {
                var increase = spaceship.DistanceTravelled / Constants.Constants.MilesConsumption;

                var decrease = spaceship.CurrentYear - spaceship.BoughtYear;

                result = Constants.Constants.CargoInitialTax + increase * Constants.Constants.CargoTaxIncrease - decrease * Constants.Constants.CargoTaxDecrese;
            }

            return result;

        }
    }
}
