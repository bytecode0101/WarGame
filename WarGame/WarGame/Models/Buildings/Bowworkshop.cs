using System;
using WarGame.Models.Capabilities;

namespace WarGame.Models.Buildings
{
    public class BowWorkshop : AbstractBuilding
    {
        #region Constructors

        public BowWorkshop(int y, int x, int life) : base(y, x, life)
        {
            TrainCapabilities.Add(typeof(TrainBowmanCapability), new TrainBowmanCapability());
            BuildCapabilities.Add(typeof(UpgradeBowWorkshopCapability), new UpgradeBowWorkshopCapability());
            progress = 10;
        }

        #endregion


    }
}
