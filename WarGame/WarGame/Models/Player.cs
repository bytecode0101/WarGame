using System.Collections.Generic;
using WarGame.Models.Buildings;
using WarGame.Models.Resources;
using WarGame.Models.Units;
using WarGame.Models.Capabilities;
using System;

namespace WarGame.Models
{
    public class Player
    {
        #region Private Fields
        private Map map;
        private Dictionary<Resource, int> resources;
        private Pawn pawn;
               
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
                return Map;
            }

            set
            {
                Map = value;
            }
        }

        public Dictionary<Resource,int> Resources
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

        public Pawn Pawn
        {
            get
            {
                return pawn;
            }

            set
            {
                pawn = value;
            }
        }

        internal List<DecoratorBuilding> Buildings
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
            //Map = new Map();
            Resources = new Dictionary<Resource, int>();
            Units = new List<AbstractUnit>();
            Buildings = new List<DecoratorBuilding>();
            TrainCapabilities = new List<AbstractTrainCapability>();
            BuildCapabilities = new List<AbstractBuildCapability>();
            //AddBuilding(new Farm(0, 0, 100));
            Pawn = new Pawn();
            Pawn.GatherEvent += Pawn_GatherEvent; 
        }

        private void Pawn_GatherEvent()
        {
            foreach (var unit in units)
            {
                Resources.Add(map.GetResourcePosition(pawn.Location), unit.Capacity);
            }
           
         

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

        private void AddBuilding(AbstractBuilding wrapper)
        {
            buildings.Add(wrapper);

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


            wrapper.Building.UnderConstructionEvent += (sender, args)=>{ Console.WriteLine("Built " + args.Percentage); };

            wrapper.Building.StartBuilding();
        }

        public void Build(AbstractBuildCapability buildCapability, DecoratorBuilding building = null)
        {
            var newbuilding = buildCapability.Build(building);

            if (building == null)
            {
                AddBuilding(newbuilding);
            }
            else
            {
                foreach(var bWrapper in Buildings)
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

        public void TrainUnit(DecoratorUnit upgrade)
        {
            var indexOfUnitToBeUpgraded = Units.IndexOf(upgrade.Unit);
            var upgradedUnit = upgrade.Upgrade();
            Units[indexOfUnitToBeUpgraded] = upgradedUnit;
        }

        public void TrainUnitCommand(AbstractUnit unit)
        {

        }
        
        public void ListUnits()
        {
            foreach (var unit in Units)
            {
                Console.WriteLine(unit);
            }
        }

        #endregion
    }
}