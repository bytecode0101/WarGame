using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarGame.Models.Units;

namespace WarGame.Models
{
    public class Pawn
    {
        private List<AbstractUnit> units;
        private Tile location;

        public void MoveToLocation(Tile argLocation)
        {
            foreach (var unit in units)
            {
                unit.GatherResource(location);
                //unit.Position = location.
            }
        }
    }
}
