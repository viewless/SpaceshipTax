using SpaceshipTax.Models.Models;

namespace SpaceshipTax.Services
{
    public interface ISpaceshipService
    {
        int CalculateTax(SpaceshipModel spaceship, string spaceshipType);
    }
}
