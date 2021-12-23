using SpaceshipTax.Models.Models;
using SpaceshipTax.Services;
using Xunit;

namespace SpaceshipTax.Tests
{
    public class SpaceshipServiceTests : IClassFixture<SpaceshipServiceFixture>
    {
        private readonly SpaceshipServiceFixture _spaceshipService;
           

        public SpaceshipServiceTests(SpaceshipServiceFixture spaceshipService)
        {
            _spaceshipService = spaceshipService;
             
        }

        [Fact]
        public void TestCalculationsOnFamilySpaceship()
        {
            //Arrange
            SpaceshipService spaceship = new SpaceshipService();
            SpaceshipModel familySpaceship = new FamilySpaceshipModel(2300, 2334, 2307);

            //Act
            int actual = spaceship.CalculateTax(familySpaceship, "family");

            //Assert
            Assert.Equal(2715, actual);
        }

        [Fact]
        public void TestCalculationsOnCargoSpaceship()
        {
            //Arrange
            SpaceshipModel cargoSpaceship = new CargoSpaceshipModel(2332, 344789, 2369);
            SpaceshipService spaceship = new SpaceshipService();

            //Act
            var actual = spaceship.CalculateTax(cargoSpaceship, "cargo");

            //Assert
            Assert.Equal(326768, actual);
        }

        [Fact]
        public void TestCalculationsOnCargoSpaceshipNotNull()
        {
            //Arrange
            var cargoSpaceshipService = new CargoSpaceshipModel(2332, 344789, 2369);

            //Act
            var actual = _spaceshipService.SpaceshipService.Setup(x => x.CalculateTax(cargoSpaceshipService, "cargo")).Returns(326768);

            //Assert
            Assert.NotNull(actual);
        }
        [Fact]
        public void TestCalculationsOnFamilySpaceshipNotNull()
        {
            //Arrange
            var familySpaceshipService = new FamilySpaceshipModel(2300, 2334, 2307);

            //Act
            var actual = _spaceshipService.SpaceshipService.Setup(x => x.CalculateTax(familySpaceshipService, "family")).Returns(326768);

            //Assert
            Assert.NotNull(actual);
        }
    }
}
