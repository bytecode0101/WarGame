
using System;

namespace WarGame.Models.Buildings
{
    class BarrackLevel2 : DecoratorBuilding
    {

        #region Constructors

        public BarrackLevel2(BarrackLevel1 barrackLevel1)
        {
            Building = barrackLevel1;
            Id = barrackLevel1.Id;
        }

        #endregion

    }
}
