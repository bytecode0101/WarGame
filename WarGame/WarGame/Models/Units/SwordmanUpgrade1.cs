using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame.Models.Units
{
    class SwordManUpgrade1 : DecoratorUnit
    {
        private int extraLife = 50;
        private int extraAttack = 5;

        public SwordManUpgrade1(Farmer farmer)
        {
            Unit = farmer;
        }

        public override void Attack()
        {
            Console.WriteLine("Attack power: " + extraLife);
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
