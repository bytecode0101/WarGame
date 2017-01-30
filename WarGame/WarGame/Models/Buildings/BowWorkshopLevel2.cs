namespace WarGame.Models.Buildings
{
    public class BowWorkshopLevel2 : DecoratorBuilding
    {
        #region Constructors

        public BowWorkshopLevel2(BowWorkshopLevel1 building)
        {
            Building = building;
            Id = Id;
        }

        #endregion
    }
}