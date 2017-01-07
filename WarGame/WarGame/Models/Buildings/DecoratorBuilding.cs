using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame.Models.Buildings
{
    abstract class DecoratorBuilding : AbstractBuilding
    {
        AbstractBuilding building;

        public DecoratorBuilding(int y, int x, int life) : base(y, x, life)
        {
        }

        public AbstractBuilding Building
        {
            get
            {
                return building;
            }

            set
            {
                building = value;
            }
        }
    }
}
