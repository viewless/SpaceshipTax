namespace SpaceshipTax.Models.Models
{
    public abstract class SpaceshipModel
    {
        public int CurrentYear { get; set; }
        public int DistanceTravelled { get; set; }
        public int BoughtYear { get; set; }

        public SpaceshipModel(int boughtYear, int distanceTravelled,  int currentYear)
        {
            BoughtYear = boughtYear;
            DistanceTravelled = distanceTravelled;
            CurrentYear = currentYear;
        }


    }
}
