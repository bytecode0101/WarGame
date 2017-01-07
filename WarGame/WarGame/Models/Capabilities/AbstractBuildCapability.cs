using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarGame.Models.Buildings;

namespace WarGame.Models.Capabilities
{
    public abstract class AbstractBuildCapability
    {
        public abstract AbstractBuilding Build(AbstractBuilding building);
    }
}
