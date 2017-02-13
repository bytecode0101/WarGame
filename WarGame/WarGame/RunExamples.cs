using NLog;
using System;
using WarGame.Models;

namespace WarGame
{
    public class RunExamples
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        static Game game;

        static Player player1;

        static void Init()
        {
            game = Game.Instance;
            game.Load("SavedGames\\Map.txt");
            ICommandReader commandReader = new FileCommandReader();
           // ICommandReader commandReader = new TcpCommandReader();
            player1 = new Player(game.Map, commandReader);
        }

        static void SimpleGameExample()
        {
            Init();
            game.Start();
            foreach (var item in game.Players)
            {


                Console.WriteLine("Life of first unit  {0}", item.Units[0].Life);
                item.Units[0].PropertyChanged += RunExamples_PropertyChanged;
                item.Units[0].Life--;

                //game.Save("SavedGames\\game2.txt");

            }
            game.SaveJson("SavedGames\\game2.txt");
        }

        private static void RunExamples_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            foreach (var item in game.Players)
            {
                if (e.PropertyName == "Life")
                {
                    Console.WriteLine("Life of first unit  {0}", item.Units[0].Life);
                }
            }
        }

        public static void Run()
        {
            //SimpleGameExample();
            Init();
            player1.ReadCommands();
            //player1.ReadCommandsFromTCP();
            // player1.ExecuteCommands();
            player1.ExecuteCommands();
            //BuildBarrack();

            //BuildUnits();
            //MoveToPosition(5, 5);
            // GatherResources();
            // player1.Attack(0, 20);
            //player1.Attack(1, 20);

        }

        private static void MoveToPosition(int x, int y)
        {
            player1.Pawn.MoveToLocation(new Point(x, y));
        }

        private static void BuildBarrack()
        {

            //player1.Build(new BuildBarrackCapability());
            // player1.Build(new UpgradeBarrackCapability(), player1.Buildings[1]);
            // player1.Build(new UpgradeBarrackCapability(), player1.Buildings[1]);

            //player1.Build(player1.BuildCapabilities[typeof(BuildBarrackCapability)]);
            //player1.Build(player1.BuildCapabilities[typeof(UpgradeBarrackCapability)], player1.Buildings[1]);
            //player1.Build(player1.BuildCapabilities[typeof(UpgradeBarrackCapability)], player1.Buildings[1]);
            //player1.Build(player1.BuildCapabilities[typeof(BuildBowWorkshopCapability)]);
            //player1.Build(player1.BuildCapabilities[typeof(UpgradeBowWorkshopCapability)], player1.Buildings[2]);
            //player1.Build(player1.BuildCapabilities[typeof(UpgradeBowWorkshopCapability)], player1.Buildings[2]);

            //player1.TrainUnit(player1.TrainCapabilities[typeof(TrainFarmerCapability)]);
            //player1.TrainUnit(player1.TrainCapabilities[typeof(TrainSwordmanCapability)],player1.Units[0]);


            //Thread.Sleep(3000);
            //////

        }

        private static void GatherResources()
        {
            //player1.Ghater();
        }

        private static void BuildUnits()
        {
            
            //AbstractUnit farmer1 = new Farmer(0, 0, 100);
            //AbstractUnit farmer2 = new Farmer(0, 0, 100);
            //AbstractUnit farmer3 = new Farmer(0, 0, 100);
            //player1.AddUnit(farmer1);
            //player1.AddUnit(farmer2);
            //player1.AddUnit(farmer3);

            //player1.ListUnits();

            //var farmer = player1.Units[0] as Farmer;
            //if (farmer!=null)
            //{
            //    player1.TrainUnit(new SwordManUpgrade1(farmer));
            //}

            //player1.ListUnits();

            //var swordman = player1.Units[0] as SwordManUpgrade1;
            //if (swordman != null)
            //{
            //    player1.TrainUnit(new SwordManUpgrade2(swordman));
            //}

            //player1.ListUnits();

            ////Map map = new Map();
            ////map.Tiles = new Tile[,] { 
            ////                            { Resource.Food, Resource.Iron, Resource.Gold, Resource.Stone, Resource.Wood }, 
            ////                            { Resource.Stone, Resource.Wood, Resource.Food, Resource.Iron, Resource.Gold }
            ////                        };
            ////player1.Map = new Map
        }

        private static void UpgradeExample()
        {
           
        }
    }
}
