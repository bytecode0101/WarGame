using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame.Models.Units
{
    class FarmerUpgrade1:DecoratorUnits
    {
        public FarmerUpgrade1(int x, int y, int life) : base(x, y, life)
        {

        }

        public override void Attack()
        {
            throw new NotImplementedException();
        }

        public override void GatherResource(Tile argTile)
        {
            throw new NotImplementedException();
        }

        public override void Move(Point destination)
        {
            throw new NotImplementedException();
        }

        public override AbstractUnit Upgrade()
        {
            DecoratorUnits upgradedFarmer = new FarmerUpgrade1(this.Position.X, this.Position.Y, 150);
            upgradedFarmer.Unit = this;

            return upgradedFarmer;
        }
    }
}
