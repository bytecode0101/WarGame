using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame.Models.Units
{
    class BowmanUpgrade2:DecoratorUnits
    {
        public BowmanUpgrade2(int x,int y,int life):base(x,y,life)
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
            throw new NotImplementedException();
        }
    }
}
