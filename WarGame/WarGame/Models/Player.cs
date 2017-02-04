using System.Collections.Generic;
using WarGame.Models.Buildings;
using WarGame.Models.Resources;
using WarGame.Models.Units;
using WarGame.Models.Capabilities;
using System;
using WarGame.Models.Events;
using System.Collections.Concurrent;
using WarGame.Models.Commands;
using System.IO;
using System.Threading;

namespace WarGame.Models
{
    public class Player
    {

        #region Threads

        private Thread ExecuteCommandsThread;

        #endregion

        #region Events

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
            foreach (var resource in Resources)
            {
                Console.WriteLine("{0}: {1}", resource.Key.ToString(), resource.Value);
            }
        }

        private void Building_UnderConstructionEvent(AbstractBuildable sender, ConstructionArgs args)
        {
            Console.WriteLine("[{0}] Built {1}% of {2}", sender.GetHashCode(), args.Percentage, sender.GetType().Name);

            if (args.Percentage == 100)
            {
                sender.UnderConstructionEvent -= Building_UnderConstructionEvent;
            }
        }

        #endregion

        #region Private Fields
        private static int numberOfPlayers = 0;

        private Map map;
        private Dictionary<Resource, int> resources;
        private Pawn pawn;

        private Dictionary<int, AbstractBuildable> buildables;
        private List<AbstractBuilding> buildings;
        private Dictionary<Type, AbstractBuildCapability> buildCapabilities;
        private Dictionary<Type, AbstractTrainCapability> trainCapabilities;
        private List<AbstractUnit> units;

        //BlockingCollection<ICommand> commands = new BlockingCollection<ICommand>();
        BlockingQueue<ICommand> commands = new BlockingQueue<ICommand>();


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

        public Dictionary<Resource, int> Resources
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

        public Dictionary<Type, AbstractBuildCapability> BuildCapabilities
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

        public Dictionary<Type, AbstractTrainCapability> TrainCapabilities
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
            TrainCapabilities = new Dictionary<Type, AbstractTrainCapability>();
            BuildCapabilities = new Dictionary<Type, AbstractBuildCapability>();

            ExecuteCommandsThread = new Thread(ExecuteCommands);

            AddBuilding(new Farm(0, 0, 100));
            Pawn = new Pawn();
            Pawn.GatherEvent += Pawn_GatherEvent;


        }




        #endregion

        #region Public Methods

        public void NewTurn()
        {

        }



        //public void TrainUnit(DecoratorUnit upgrade)
        //{
        //    var indexOfUnitToBeUpgraded = Units.IndexOf(upgrade.Unit);
        //    var upgradedUnit = upgrade.Upgrade();
        //    Units[indexOfUnitToBeUpgraded] = upgradedUnit;
        //    upgradedUnit.Id = upgrade.Unit.Id;
        //    Buildables[upgrade.Unit.Id] = upgradedUnit;
        //}

        #endregion

        #region Private Methods

        private void Build(AbstractBuildCapability buildCapability, AbstractBuilding building = null)
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
                Buildables[building.Id] = newbuilding;
            }


        }

        private void TrainUnit(AbstractTrainCapability trainCapability, AbstractUnit unit = null)
        {
            var newunit = trainCapability.Train(unit);
            if (unit == null)
            {
                AddUnit(newunit);
            }
            else
            {
                RemoveUnit(unit);
                Units.Add(newunit);
                Buildables[unit.Id] = newunit;
            }
        }

        private void Attack(int buildableId, int attackStrength)
        {
            Buildables[buildableId].UnderAttackEvent += (sender, args) => { Console.WriteLine("[{0} - {1}] Buildable is under attack. Current life {2}", sender.Id, sender.GetType().Name, sender.Life); };
            Buildables[buildableId].Attack(attackStrength);
        }

        private void Move(int x, int y)
        {
            pawn.MoveToLocation(new Point(x, y));
        }

        private void Ghater()
        {
            Pawn.GatherResources();
        }

        private void AddUnit(AbstractUnit unit)
        {
            Units.Add(unit);
            Buildables.Add(unit.Id, unit);
        }

        private void AddBuilding(AbstractBuilding building)
        {
            Buildings.Add(building);
            Buildables.Add(building.Id, building);

            foreach (var capability in building.BuildCapabilities)
            {
                if (!BuildCapabilities.ContainsKey(capability.Key))
                    BuildCapabilities.Add(capability.Key, capability.Value);
            }

            foreach (var capability in building.TrainCapabilities)
            {
                if (!TrainCapabilities.ContainsKey(capability.Key))
                    TrainCapabilities.Add(capability.Key, capability.Value);
            }

            building.UnderConstructionEvent += Building_UnderConstructionEvent;
            building.StartBuilding();
        }

        private void RemoveBuilding(AbstractBuilding building)
        {
            //TODO:unsubscribe from events
            Buildings.Remove(building);

        }

        private void RemoveUnit(AbstractUnit unit)
        {
            //TODO: unsubscribe from events
            Units.Remove(unit);
        }
        
        #endregion

        #region Test Methods

        public void ListUnits()
        {
            Console.WriteLine("Player Units:");
            foreach (var unit in Units)
            {
                Console.WriteLine(unit);
            }
            Console.WriteLine("");
        }

        public void ListBuildings()
        {
            Console.WriteLine("Player Buildings:");
            foreach (var building in Buildings)
            {
                Console.WriteLine(building);
            }
            Console.WriteLine("");
        }

        public void ReadCommands()
        {
            
            using (var sr = new StreamReader("SavedGames\\script.txt"))
            {
                string cmdText;
                while (!sr.EndOfStream)
                {
                    cmdText = sr.ReadLine();
                    var commandName = cmdText.Split(' ')[0];
                    string args = "";
                    if (cmdText.Contains(" "))
                        args = cmdText.Split(' ')[1];
                    PlayerCommand playerCommand;
                    switch (commandName)
                    {
                        case "Move":
                            {
                                int x;
                                int.TryParse(args.Split(',')[0], out x);
                                int y;
                                int.TryParse(args.Split(',')[1], out y);
                                playerCommand = new PlayerCommand(() =>
                                {
                                    Move(x, y);
                                });
                                commands.TryAdd(playerCommand);
                            }
                            break;
                        case "Gather":
                            {
                                playerCommand = new PlayerCommand(() =>
                                {
                                    Ghater();
                                });
                                commands.TryAdd(playerCommand);
                            }
                            break;
                        case "Build":
                            {
                                playerCommand = new PlayerCommand(() =>
                                {
                                    switch (args)
                                    {
                                        case "Barrack":
                                            Build(BuildCapabilities[typeof(BuildBarrackCapability)]);
                                            break;
                                        case "BowWorkshop":
                                            Build(BuildCapabilities[typeof(BuildBowWorkshopCapability)]);
                                            break;
                                        default:
                                            break;
                                    }
                                });
                                commands.TryAdd(playerCommand);
                            }
                            break;
                        case "Attack":
                            {
                                playerCommand = new PlayerCommand(() =>
                                {
                                    int unitID;
                                    int attackStrength;
                                    int.TryParse(args.Split(',')[0], out unitID);
                                    int.TryParse(args.Split(',')[1], out attackStrength);
                                    Attack(unitID, attackStrength);
                                });
                                commands.TryAdd(playerCommand);
                            }
                            break;
                        case "List":
                            {
                                switch(args)
                                {
                                    case "Units":
                                        {
                                            playerCommand = new PlayerCommand(() =>
                                            {
                                                ListUnits();
                                            });
                                            commands.TryAdd(playerCommand);
                                        }
                                        break;
                                    case "Buildings":
                                        {
                                            playerCommand = new PlayerCommand(() =>
                                            {
                                                ListBuildings();
                                            });
                                            commands.TryAdd(playerCommand);
                                        }
                                        break;
                                    default:
                                        //TODO:...
                                        break;
                                }
                            }
                            break;
                        case "Train":
                            var playerTrainCommand = new PlayerCommand(() =>
                            {
                                string unitType = "";
                                int unitID = 0;
                                if (args.Contains(","))
                                {
                                    unitType = args.Split(',')[0];
                                    int.TryParse(args.Split(',')[1], out unitID);
                                }
                                else
                                {
                                    unitType = args;
                                }
                                switch (unitType)
                                {
                                    case "Farmer":
                                        TrainUnit(TrainCapabilities[typeof(TrainFarmerCapability)]);
                                        break;
                                    case "Swordman":
                                        //var swordman = new Farmer(0, 0, 100);
                                        var unit = Buildables[unitID] as Farmer;
                                        if (unit != null)
                                        {
                                            //TrainUnit(new SwordManUpgrade1(unit));
                                            TrainUnit(TrainCapabilities[typeof(TrainSwordmanCapability)], unit);
                                        }
                                        else
                                        {
                                            //TODO: throw exeception
                                        }
                                        break;
                                    case "Bowman":
                                        //var swordman = new Farmer(0, 0, 100);
                                        var unit1 = Buildables[unitID] as Farmer;
                                        if (unit1 != null)
                                        {
                                            //TrainUnit(new BowmanUpgrade1(unit1));
                                            TrainUnit(TrainCapabilities[typeof(TrainBowmanCapability)], unit1);
                                        }
                                        else
                                        {
                                            //TODO: throw exeception
                                        }
                                        break;
                                    default:
                                        break;
                                }

                            });
                            commands.TryAdd(playerTrainCommand);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public void StartCommndsExecution()
        {
            ExecuteCommandsThread.Start();
        }

        private void ExecuteCommands()
        {
            while (true)
            {
                ICommand command;
                commands.TryTake(out command);
                if (command != null)
                {
                    Console.WriteLine("Executing command from thread [{0}]", Thread.CurrentThread.ManagedThreadId);
                    command.Execute();
                }
            }
        }

        #endregion
    }
}