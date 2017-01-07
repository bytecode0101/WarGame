using System.Collections.Generic;
using WarGame.Models.Buildings;
using WarGame.Models.Resources;
using WarGame.Models.Units;
using WarGame.Models.Capabilities;

namespace WarGame.Models
{
    public class Player
    {
        #region Private Fields
        private Map map;
        private List<Resource> resources;
        
        private List<AbstractBuilding> buildings; 
        private List<AbstractBuildCapability> buildCapabilities; 
        private List<AbstractTrainCapability> trainCapabilities; 
        private List<AbstractUnit> units; 

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


        public List<AbstractBuilding> Buildings
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

        public List<AbstractUnit> Units
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

        public List<AbstractTrainCapability> TrainCapabilities
        {
            get
            {
                return trainCapabilities;
            }

            set
            {
                trainCapabilities = value;
            }
        }

        public List<AbstractBuildCapability> BuildCapabilities
        {
            get
            {
                return buildCapabilities;
            }

            set
            {
                buildCapabilities = value;
            }
        }
        #endregion

        #region Constructors
        public Player()
        {
            map = new Map();
            Resources = new List<Resource>();
            Units = new List<AbstractUnit>();
            Buildings = new List<AbstractBuilding>();
            TrainCapabilities = new List<AbstractTrainCapability>();
            BuildCapabilities = new List<AbstractBuildCapability>();
            AddBuilding(new Farm(0, 0, 100));

        }

     
        #endregion

        #region Public Methods
        public void NewTurn()
        {

        }

        public void AddUnit(AbstractUnit unit)
        {
            Units.Add(unit);
        }

        private void AddBuilding(AbstractBuilding building)
        {
            Buildings.Add(building);

            bool capabilityExists = false;
            foreach (var capability in building.BuildCapabilities)
            {
                capabilityExists = false;
                foreach (var bcapability in BuildCapabilities)
                    if (bcapability.GetType() == capability.GetType())
                    {
                        capabilityExists = true;
                        break;
                    }
                if (!capabilityExists)
                    BuildCapabilities.Add(capability);
            }

            foreach (var capability in building.TrainCapabilities)
            {
                capabilityExists = false;
                foreach (var bcapability in BuildCapabilities)
                    if (bcapability.GetType() == capability.GetType())
                    {
                        capabilityExists = true;
                        break;
                    }
                if (!capabilityExists)
                    TrainCapabilities.Add(capability);
            }
        }

        public void Build(AbstractBuildCapability buildCapability, AbstractBuilding building = null)
        {
            var newbuilding = buildCapability.Build(building);
            if (building == null)
            {
            
            AddBuilding(newbuilding);
            }
            else
            { building = newbuilding; }
        }

        #endregion
    }
}