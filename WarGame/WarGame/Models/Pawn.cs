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
        private Point location;

        public Point Location
        {
            get
            {
                return location;
            }

            set
            {
                location = value;
            }
        }

        public event GatherEvent GatherEvent;

        public void MoveToLocation(Point argLocation)
        {
            Location = argLocation;
        }

        
        private void OnResourceGathered()
        {
            GatherEvent?.Invoke();

            System.Console.WriteLine("Resources were gathered.");
        }

        public void GatherResources()
        {
            GatherEvent?.Invoke();

            System.Console.WriteLine("Resources were gathered.");
        }
    }
}
