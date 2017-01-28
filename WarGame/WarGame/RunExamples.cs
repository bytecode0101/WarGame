using System;
using System.Collections.Generic;
using WarGame.Models;
using WarGame.Models.Buildings;
using WarGame.Models.Capabilities;
using WarGame.Models.Resources;
using WarGame.Models.Units;

namespace WarGame
{
    public class RunExamples
    {
        static Game game;

        static void Init()
        {
            game = new Game();
            game.Load("SavedGames\\game1.txt");
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
            Player player1 = new Player();

            player1.Build(new BuildBarrackCapability());
            player1.Build(new UpgradeBarrackCapability(), player1.Buildings[1]);

            GatheringResources();
        }

        private static void GatheringResources()
        {
            Player player1 = new Player();
            AbstractUnit farmer1 = new Farmer(0, 0, 100);
            farmer1.Capacity = 10;
            AbstractUnit farmer2 = new Farmer(0, 0, 100);
            AbstractUnit farmer3 = new Farmer(0, 0, 100);
            farmer3.Capacity = 10;
            player1.Units.Add(farmer1);
            player1.Units.Add(farmer2);
            player1.Units.Add(farmer3);

            player1.ListUnits();

            var farmer = player1.Units[0] as Farmer;
            if (farmer!=null)
            {
                player1.UpgradeUnit(new SwordManUpgrade1(farmer));
            }

            player1.ListUnits();

            var swordman = player1.Units[0] as SwordManUpgrade1;
            if (swordman != null)
            {
                player1.UpgradeUnit(new SwordManUpgrade2(swordman));
            }

            player1.ListUnits();

            //Map map = new Map();
            //map.Tiles = new Tile[,] { 
            //                            { Resource.Food, Resource.Iron, Resource.Gold, Resource.Stone, Resource.Wood }, 
            //                            { Resource.Stone, Resource.Wood, Resource.Food, Resource.Iron, Resource.Gold }
            //                        };
            //player1.Map = new Map
        }

        private static void UpgradeExample()
        {
           
        }
    }
}
