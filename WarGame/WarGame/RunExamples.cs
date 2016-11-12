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
            Console.WriteLine("Life of first unit  {0}", game.Player.Units[0].Life);
            game.Player.Units[0].PropertyChanged += RunExamples_PropertyChanged;
            game.Player.Units[0].Life--;
            game.Start();
            //game.Save("SavedGames\\game2.txt");
            game.SaveJson("SavedGames\\game2.txt");
        }

        private static void RunExamples_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Life")
            {
                Console.WriteLine("Life of first unit  {0}", game.Player.Units[0].Life);
            }
        }

        public static void Run()
        {
            SimpleGameExample();
        }
    }
}
