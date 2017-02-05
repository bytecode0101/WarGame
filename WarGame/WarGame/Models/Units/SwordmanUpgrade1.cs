using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame.Models.Units
{
    class SwordManUpgrade1 : DecoratorUnit
    {
        

        public SwordManUpgrade1(Farmer farmer)
        {
            Unit = farmer;
            Life = farmer.Life + extraLife;
        }

        public override void Attack()
        {
            //Console.WriteLine("Attack power: " + extraLife);
        }

        

        public override void Move(Point destination)
        {
            throw new NotImplementedException();
        }
    }
}
