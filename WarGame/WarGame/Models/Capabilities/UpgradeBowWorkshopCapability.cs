using System;
using WarGame.Models.Buildings;

namespace WarGame.Models.Capabilities
{
    class UpgradeBowWorkshopCapability : AbstractBuildCapability
    {

        #region Public Methods

        public override AbstractBuilding Build(AbstractBuilding building)
        {
            DecoratorBuilding upgradedWorkshop;

            if (building.GetType() == typeof(BowWorkshop))
            {
                upgradedWorkshop = new BowWorkshopLevel1(building as BowWorkshop);
            }
            else if (building.GetType() == typeof(BowWorkshopLevel1))
            {
                upgradedWorkshop = new BowWorkshopLevel2(building as BowWorkshopLevel1);
            }
            else
            {
                // throw new InvalidOperationException(String.Format("Building of type {0} doesn't exist.", building.GetType().Name));
                throw new InvalidOperationException(String.Format("Reached maximum upgrade level for building [{0}] {1}.", building.Id, building.GetType().Name));
            }
            upgradedWorkshop.Id = building.Id;
            upgradedWorkshop.Building = building;

            return upgradedWorkshop;
        }

        #endregion

    }
}
