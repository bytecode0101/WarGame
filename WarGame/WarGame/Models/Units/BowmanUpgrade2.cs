using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarGame.Models.Units;

namespace WarGame.Models.Units
{
    class BowmanUpgrade2:DecoratorUnit
    {
        public BowmanUpgrade2(BowmanUpgrade1 farmer)
        {
            Unit = farmer;
            Life = farmer.Life + extraLife;
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
    }
}
