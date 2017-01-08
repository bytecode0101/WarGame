
using System;

namespace WarGame.Models.Buildings
{
    class BarrackLevel2 : DecoratorBuilding
    {
        public BarrackLevel2(int y, int x, int life) : base(y, x, life)
        {
        }

        public override AbstractBuilding Upgrade()
        {
            throw new NotImplementedException();
        }
    }
}
