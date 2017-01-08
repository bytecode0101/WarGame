using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame.Models.Units
{
    class SwordManUpgrade1<T> : DecoratorUnit<T> where T : Farmer
    {
        private int extraLife = 50;
        private int extraAttack = 5;

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
