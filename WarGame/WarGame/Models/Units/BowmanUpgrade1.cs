using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame.Models.Units
{
    class BowmanUpgrade1 :DecoratorUnit
    {
        public BowmanUpgrade1(Farmer farmer)
        {
            Unit = farmer;
            Life = farmer.Life + extraLife;
        }    

        public override void Attack()
        {
            throw new NotImplementedException();
        }

        public override void Move(Point destination)
        {
            throw new NotImplementedException();
        }
    }
}
