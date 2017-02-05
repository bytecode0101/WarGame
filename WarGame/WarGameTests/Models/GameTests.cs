using Microsoft.VisualStudio.TestTools.UnitTesting;
using WarGame.Models.Resources;
using WarGame.Models.Units;
using System.Threading;

namespace WarGame.Models.Tests
{
    [TestClass()]
    public class GameTests
    {
        Game game;
        Player player;

        [TestInitialize]
        public void Init()
        {
            game = Game.Instance;
            game.Load("SavedGames\\Map.txt");

            //ICommandReader commandReader = new FileCommandReader();
            ICommandReader commandReader = new FileCommandReader();
            player = new Player(game.Map, commandReader);
           
        }

        [TestMethod()]
        public void GameTest()
        {
           Assert.AreEqual(game.Map.GetResource(new Point(0, 0)), Resource.Food);
           Assert.AreEqual(game.Map.GetResource(new Point(1, 1)), Resource.Wood);
           Assert.AreEqual(game.Map.GetResource(new Point(2, 2)), Resource.Iron);
           Assert.AreEqual(game.Map.GetResource(new Point(8, 8)), Resource.Gold);
        }

        [TestMethod()]
        public void PlayerTest()
        {
            Assert.AreEqual(player.Pawn.Location.X, 0);
            Assert.AreEqual(player.Pawn.Location.Y, 0);

            player.ReadCommands();
            player.ExecuteCommands();
            Thread.Sleep(5000);
            Assert.AreEqual(player.Pawn.Location.X, 5);
            Assert.AreEqual(player.Pawn.Location.Y, 5);

            Assert.AreEqual(player.Buildables[2].GetType(), typeof(BowmanUpgrade1));


        }

        [TestMethod()]
        public void LoadTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SaveTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SaveJsonTest()
        {
            Assert.Fail();
        }
    }
}