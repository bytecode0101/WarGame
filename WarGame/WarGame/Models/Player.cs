using System.Collections.Generic;
using WarGame.Models.Buildings;
using WarGame.Models.Resources;
using WarGame.Models.Units;
using WarGame.Models.Capabilities;
using System;
using WarGame.Models.Events;

namespace WarGame.Models
{
    public class Player
    {
        #region Private Fields
        private static int numberOfPlayers = 0;

        private Map map;
        private Dictionary<Resource, int> resources;
        private Pawn pawn;

        private Dictionary<int,AbstractBuildable> buildables;       
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

        public int Id { get; private set; }

        public Dictionary<int, AbstractBuildable> Buildables
        {
            get
            {
                return buildables;
            }

            set
            {
                buildables = value;
            }
        }



        #endregion

        #region Constructors
        public Player(Map map)
        {
            Map = map;
            Id = numberOfPlayers++;
            Resources = new Dictionary<Resource, int>();
            Units = new List<AbstractUnit>();
            Buildables = new Dictionary<int, AbstractBuildable>();
            Buildings = new List<AbstractBuilding>();
            TrainCapabilities = new List<AbstractTrainCapability>();
            BuildCapabilities = new List<AbstractBuildCapability>();
            AddBuilding(new Farm(0, 0, 100));
            Pawn = new Pawn();
            Pawn.GatherEvent += Pawn_GatherEvent; 
        }

        private void Pawn_GatherEvent()
        {
            foreach (var unit in units)
            {
                if (unit.GetType() == typeof(Farmer))
                {
                    if (Resources.ContainsKey(map.GetResourcePosition(pawn.Location)))
                    {
                        Resources[map.GetResourcePosition(pawn.Location)]++;
                    }
                    else
                    {
                        Resources.Add(map.GetResourcePosition(pawn.Location), 1);
                    }
                }
            }

            Console.WriteLine("Current Resources:");
            foreach(var resource in Resources)
            {
                Console.WriteLine("{0}: {1}",resource.Key.ToString(), resource.Value);
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
            Buildables.Add(unit.Id, unit);
            
        }

        private void AddBuilding(AbstractBuilding building)
        {
            Buildings.Add(building);
            Buildables.Add(building.Id, building);

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


            building.UnderConstructionEvent += Building_UnderConstructionEvent; 
            building.StartBuilding();
        }

        private void Building_UnderConstructionEvent(AbstractBuildable sender, ConstructionArgs args)
        {
            Console.WriteLine("[{0}] Built {1} {2}",sender.GetHashCode(), args.Percentage, sender.GetType().Name);

            if(args.Percentage == 100)
            {
                sender.UnderConstructionEvent -= Building_UnderConstructionEvent;
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
            {
                RemoveBuilding(building);
                Buildings.Add(newbuilding);
            }
        }

        private void RemoveBuilding(AbstractBuilding building)
        {
                //TO DO:unsubscribe from events
                Buildings.Remove(building);
        }

        public void Attack(int buildableId, int attackStrength)
        {
            Buildables[buildableId].UnderAttackEvent += (sender, args) => { Console.WriteLine("[{0} - {1}] Buildable is under attack. Current life {2}", sender.Id ,sender.GetType().Name, sender.Life); };
            Buildables[buildableId].Attack(attackStrength);
        }

        public void Move(int x, int y)
        {
            pawn.MoveToLocation(new Point(x, y));
        }

        public void Ghater()
        {
            Pawn.GatherResources();
        }


        public void TrainUnit(DecoratorUnit upgrade)
        {
            var indexOfUnitToBeUpgraded = Units.IndexOf(upgrade.Unit);
            var upgradedUnit = upgrade.Upgrade();
            Units[indexOfUnitToBeUpgraded] = upgradedUnit;
            upgradedUnit.Id = upgrade.Unit.Id;
            Buildables[upgrade.Unit.Id] = upgradedUnit;
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