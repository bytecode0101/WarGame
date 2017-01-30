using System;
using WarGame.Models.Capabilities;


namespace WarGame.Models.Buildings

{
    class Barrack : AbstractBuilding
    {

        #region Constructors

        public Barrack(int y, int x, int life) : base(y, x, life)
        {
            BuildCapabilities.Add(typeof(BuildBowWorkshopCapability), new BuildBowWorkshopCapability());
            BuildCapabilities.Add(typeof(UpgradeBarrackCapability), new UpgradeBarrackCapability());
            TrainCapabilities.Add(typeof(TrainSwordmanCapability), new TrainSwordmanCapability());
            progress = 10;
        }

        #endregion

        #region Public Methods

        #endregion
    }
}
