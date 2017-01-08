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

        public event GatherEvent GatherEvent;

        public void MoveToLocation(Tile argLocation)
        {

        }

        
        private void OnResourceGathered(Point location)
        {
            if (GatherEvent != null)
            {
                GatherEvent(location);
            }

            System.Console.WriteLine("Resources were gathered.");
        }
    }
}
