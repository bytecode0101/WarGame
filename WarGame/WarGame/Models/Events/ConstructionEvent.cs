using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarGame.Models.Buildings;

namespace WarGame.Models.Events
{
    public delegate void UnderConstruction(AbstractBuilding sender, ConstructionArgs args);
}
