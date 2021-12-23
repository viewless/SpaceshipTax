using SpaceshipTax.Models.Models;
using SpaceshipTax.Models.RequestModels;
using SpaceshipTax.Services;
using System;

namespace SpaceshipTax
{
    internal class Program
    {
        static void Main()
        {
            //"Family spaceship bought in 2300 has traveled 2_344 light miles, so in 2307 owes:";
            //"Cargo spaceship bought in 2332 has traveled 344_789 light miles, so in 2369 owes:";

            string spaceshipType;
            int yearBought, milesTravelled, currentYear;

            TakeInputAndCast(out spaceshipType, out yearBought, out milesTravelled, out currentYear);
            PrintResult(spaceshipType, yearBought, milesTravelled, currentYear);

        }

        private static void PrintResult(string spaceshipType, int yearBought, int milesTravelled, int currentYear)
        {
            SpaceshipService spaceship = new();
           
            if (spaceshipType == "cargo")
            {
                SpaceshipModel cargoSpaceship = new CargoSpaceshipModel(yearBought, milesTravelled, currentYear);

                var validation = Validate(cargoSpaceship);
                if (validation)
                {
                    Console.WriteLine("Cargo spaceship -> " + spaceship.CalculateTax(cargoSpaceship, spaceshipType));
                }
            }
            else if (spaceshipType == "family")
            {
                SpaceshipModel familySpaceship = new FamilySpaceshipModel(yearBought, milesTravelled, currentYear);
                
                var validation = Validate(familySpaceship);
                if (validation)
                {
                    Console.WriteLine("Family spaceship -> " + spaceship.CalculateTax(familySpaceship, spaceshipType));
                }
            }
        }

        private static bool Validate(SpaceshipModel spaceship)
        {
            var validator = new SpaceshipValidator();

            var result = validator.Validate(spaceship);

            if (!result.IsValid)
            {
                foreach (var falure in result.Errors)
                {
                    Console.WriteLine(falure.ErrorMessage);
                }
            }
            return result.IsValid;
        }

        private static void TakeInputAndCast(out string spaceshipType, out int yearBought, out int milesTravelled, out int currentYear)
        {
            string input = Console.ReadLine();
            string[] splitedInput = input.Split(' ');

            spaceshipType = splitedInput[0].ToLower();
            yearBought = int.Parse(splitedInput[4].Replace("_", string.Empty));
            milesTravelled = int.Parse(splitedInput[7].Replace("_", string.Empty));
            currentYear = int.Parse(splitedInput[12].Replace("_", string.Empty));
        }
    }
}
