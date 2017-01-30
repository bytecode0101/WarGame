using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarGame.Models.Units;

namespace WarGame.Models.Capabilities
{
    class TrainBowmanCapability : AbstractTrainCapability
    {
        public override AbstractUnit Train(AbstractUnit unit)
        {
            DecoratorUnit upgradedUnit;

            if (unit.GetType() == typeof(Farmer))
            {
                upgradedUnit = new BowmanUpgrade1(unit as Farmer);
            }
            else if (unit.GetType() == typeof(BowmanUpgrade1))
            {
                upgradedUnit = new BowmanUpgrade2(unit as BowmanUpgrade1);
            }
            else
            {
                // throw new InvalidOperationException(String.Format("Building of type {0} doesn't exist.", building.GetType().Name));
                throw new InvalidOperationException(String.Format("Reached maximum upgrade level for unit [{0}] {1}.", unit.Id, unit.GetType().Name));
            }
            upgradedUnit.Id = unit.Id;
            upgradedUnit.Unit = unit;

            return upgradedUnit;
        }
    }
}
