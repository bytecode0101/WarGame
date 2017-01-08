using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame.Models.Units
{
    class UnitWrapper
    {
        public AbstractUnit Unit{ get; set; }

        public UnitWrapper(AbstractUnit unit)
        {
            Unit = unit;
        }

        public void Upgrade(DecoratorUnit<AbstractUnit> upgrade)
        {
            var upgradedUnit = upgrade.Upgrade(Unit);
            Unit = upgradedUnit;
        }
    }
}
