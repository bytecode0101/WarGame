using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame.Models.Commands
{
    class BlockingQueue<T>
    {
        private List<T> queue;
        private object qLock;

        public BlockingQueue()
        {
            queue = new List<T>();
            qLock = new object();
        }

        public void TryAdd(T command)
        {
            lock (qLock)
            {
                queue.Add(command);
            }
        }
        public void TryTake(out T command)
        {
            command = default(T);
            lock (qLock)
            {
                if (queue.Count > 0)
                {
                    command = queue[0];
                    queue.RemoveAt(0);
                }
            }
        }
    }
}
