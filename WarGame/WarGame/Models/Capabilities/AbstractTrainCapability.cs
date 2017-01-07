using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarGame.Models.Units;

namespace WarGame.Models.Capabilities
{
    public abstract class AbstractTrainCapability
    {
        public abstract AbstractUnit Train(AbstractUnit unit);

    }
}
