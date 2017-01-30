using WarGame.Models.Units;
using WarGame.Models.Capabilities;
using System;

namespace WarGame.Models.Buildings
{
    public class Farm : AbstractBuilding
    {

        #region Constructors

        public Farm(int y, int x, int life) : base(y, x, life)
        {
            BuildCapabilities.Add(typeof(BuildBarrackCapability), new BuildBarrackCapability());
            TrainCapabilities.Add(typeof(TrainFarmerCapability), new TrainFarmerCapability());
            progress = 20;
        }

        #endregion

        #region Public Methods
         
        #endregion

    }
}
