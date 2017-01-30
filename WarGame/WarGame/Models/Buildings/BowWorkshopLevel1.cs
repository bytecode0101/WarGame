namespace WarGame.Models.Buildings
{
    public class BowWorkshopLevel1 : DecoratorBuilding
    {
        #region Constructors

        public BowWorkshopLevel1(BowWorkshop building)
        {
            Building = building;
            Id = building.Id;
        }

        #endregion
    }
}
