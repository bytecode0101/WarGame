using WarGame.Models.Events;

namespace WarGame.Models
{

    public interface ICommandReader
    {
        event PushCommand PushCommandEvent;
        void ReadCommands();
    }
}