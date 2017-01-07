using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarGame.Models.Resources;

namespace WarGame.Models.Buildings
{
    class Warehouse: AbstractBuilding
    {
        #region Private Fields

        List<Resource> resources;

        #endregion

        #region Constructros

        public Warehouse(int y, int x, int life) : base(y, x, life)
        {

        }
        #endregion

        #region Properties

        public List<Resource> Resources
        {
            get
            {
                return resources;
            }

            private set
            {
                resources = value;
            }
        }
        #endregion

        #region Public Methods

        public void AddResources(List<Resource> resources)
        {
            Resources.AddRange(resources);
        }

        public void RemoveResources(List<Resource> resources)
        {
            
            foreach(var resource in resources)
                foreach(var warehouseResource in Resources)
                {
                    if(resource.GetType()==warehouseResource.GetType())
                    {
                        Resources.Remove(warehouseResource);
                    }
                }
        }

        #endregion
    }
}
