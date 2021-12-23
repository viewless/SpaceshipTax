using Moq;
using SpaceshipTax.Services;

namespace SpaceshipTax.Tests
{
    public class SpaceshipServiceFixture
    {
        public Mock<ISpaceshipService> SpaceshipService { get;  set; }
       
        public SpaceshipServiceFixture()
        {
            this.SpaceshipService = new Mock<ISpaceshipService>();

        }
    }
}
