using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarGame.Models.Units;

namespace WarGame.Models.Capabilities
{
    public class TrainFarmerCapability : AbstractTrainCapability
    {
        public override AbstractUnit Train(AbstractUnit unit)
        {
            return new Farmer(0,0,100);
        }
    }
}
