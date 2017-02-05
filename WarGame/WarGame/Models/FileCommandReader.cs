using NLog;
using System.IO;
using WarGame.Models.Events;

namespace WarGame.Models
{
    public class FileCommandReader : ICommandReader
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public event PushCommand PushCommandEvent;

        /// <summary>
        /// Read commands from a local file
        /// </summary>
        public void ReadCommands()
        {
            using (var sr = new StreamReader("SavedGames\\script.txt"))
            {
                string cmdText;
                while (!sr.EndOfStream)
                {
                    //Thread.Sleep(10);
                    cmdText = sr.ReadLine();
                    //AddCommandToQueue(cmdText);
                    PushCommandEvent?.Invoke(this, new PushCommandArgs() { Command = cmdText });
                }
            }
        }
    }
}
