using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame.Models.Buildings
{
    public abstract class DecoratorBuilding : AbstractBuilding
    {
        #region Private Fields

        private AbstractBuilding building;

        #endregion
         
        #region Properties

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

        #endregion
    }
}
