using System;
using WarGame.Models.Capabilities;


namespace WarGame.Models.Buildings

{
    class Barrack : AbstractBuilding
    {
        public Barrack(int y, int x, int life) : base(y, x, life)
        {
            BuildCapabilities.Add(new BuildBowWorkshopCapability());
            TrainCapabilities.Add(new TrainSwordmanCapability());
        }

        public override AbstractBuilding Upgrade()
        {
            DecoratorBuilding upgradedBarrack = new BarrackLevel1(this.Position.X,this.Position.Y,100);
            upgradedBarrack.Building = this;

            return upgradedBarrack;
        }
    }
}
