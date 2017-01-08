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
            DecoratorBuilding upgradedBarrack = new BarrackLevel2(this.Position.X, this.Position.Y, 100);
            upgradedBarrack.Building = this;

            return upgradedBarrack;
        }
    }
}
