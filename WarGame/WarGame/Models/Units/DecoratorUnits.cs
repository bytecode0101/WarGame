using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame.Models.Units
{
    abstract class DecoratorUnits:AbstractUnit
    {
        AbstractUnit unit;

        public DecoratorUnits(int x,int y ,int life):base (x,y,life)
        {

        }

        public AbstractUnit Unit
        {
            get
            {
                return unit;
            }

            set
            {
                unit = value;
            }
        }
    }
}
