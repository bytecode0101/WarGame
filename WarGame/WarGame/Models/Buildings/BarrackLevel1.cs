using System;

namespace WarGame.Models.Buildings
{
    class BarrackLevel1 : DecoratorBuilding
    {
        public BarrackLevel1(int y, int x, int life) : base(y, x, life)
        {
        }

        public override AbstractBuilding Upgrade()
        {
            throw new NotImplementedException();
        }
    }
}
