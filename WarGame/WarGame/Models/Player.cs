using System.Collections.Generic;
using WarGame.Models.Buildings;
using WarGame.Models.Resources;
using WarGame.Models.Units;
using WarGame.Models.Capabilities;
using WarGame.Wrapper;

namespace WarGame.Models
{
    public class Player
    {
        #region Private Fields
        private Map map;
        private List<Resource> resources;
        
        private List<BuildingWrapper> buildingWrappers; 
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

        internal List<BuildingWrapper> BuildingWrappers
        {
            get
            {
                return buildingWrappers;
            }

            set
            {
                buildingWrappers = value;
            }
        }



        #endregion

        #region Constructors
        public Player()
        {
            map = new Map();
            Resources = new List<Resource>();
            Units = new List<AbstractUnit>();
            BuildingWrappers = new List<BuildingWrapper>();
            TrainCapabilities = new List<AbstractTrainCapability>();
            BuildCapabilities = new List<AbstractBuildCapability>();
            AddBuilding(new BuildingWrapper(new Farm(0, 0, 100)));

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

        private void AddBuilding(BuildingWrapper wrapper)
        {
            BuildingWrappers.Add(wrapper);

            bool capabilityExists = false;
            foreach (var capability in wrapper.Building.BuildCapabilities)
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

            foreach (var capability in wrapper.Building.TrainCapabilities)
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
            BuildingWrapper wrapper = new BuildingWrapper(newbuilding);
            if (building == null)
            {
                AddBuilding(wrapper);
            }
            else
            {
                foreach(var bWrapper in BuildingWrappers)
                {
                    if (bWrapper.Building == building)
                    {
                        bWrapper.Building = newbuilding;
                        break;
                    }
                }
            }
        }
        
        public void Attack(int x, int y)
        {

        }

        public void Move(int x, int y)
        {

        }

        #endregion
    }
}