using System.Collections.Generic;
using WarGame.Models.Buildings;
using WarGame.Models.Resources;
using WarGame.Models.Units;

namespace WarGame.Models
{
    public class Player
    {
        #region Private Fields
        private Map map;
        private List<Resource> resources;
        private List<Unit> units;
        private List<Building> buildings; 
        #endregion

        #region Properties
        public Map Map
        {
            get
            {
                return map;
            }

            set
            {
                map = value;
            }
        }

        public List<Resource> Resources
        {
            get
            {
                return resources;
            }

            set
            {
                resources = value;
            }
        }

        public List<Unit> Units
        {
            get
            {
                return units;
            }

            set
            {
                units = value;
            }
        }

        public List<Building> Buildings
        {
            get
            {
                return buildings;
            }

            set
            {
                buildings = value;
            }
        }
        #endregion

        #region Constructors
        public Player()
        {
            map = new Map();
            Resources = new List<Resource>();
            Units = new List<Unit>();
            Buildings = new List<Building>();
        }

        public void AddUnit(Unit unit)
        {
            Units.Add(unit);
        }

        internal void AddBuilding(Building building)
        {
            Buildings.Add(building);
        }
        #endregion
    }
}