using System;

namespace WarGame.Models.Buildings
{
    class BarrackLevel1 : DecoratorBuilding
    {
        #region Constructors

        public BarrackLevel1(Barrack barrack) 
        {
            Building = barrack;
            Id = barrack.Id;
        }

        #endregion
 
    }
}
