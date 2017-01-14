using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame.Models.Units
{
    class SwordManUpgrade2 : DecoratorUnit
    {

        public SwordManUpgrade2(SwordManUpgrade1 unit) 
        {
            Unit = unit;
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
