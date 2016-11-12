using System;
using WarGame.Models;

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
            SimpleGameExample();
        }
    }
}
