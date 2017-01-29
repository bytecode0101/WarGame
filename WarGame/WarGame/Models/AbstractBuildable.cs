using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarGame.Models.Events;

namespace WarGame.Models
{
    public abstract class AbstractBuildable
    {
        #region Events
        public event UnderConstruction UnderConstructionEvent;
        #endregion

        protected int life;
        protected int progress;


        public void StartBuilding()
        {
            Game.Instance.NewTurnEvent += UnderContructionProgress;
        }

        protected virtual void UnderContructionProgress(Game sender, NewTurnArgs args)
        {
            if (life < 100)
            {
                life += progress;
                UnderConstructionEvent?.Invoke(this, new ConstructionArgs() { Percentage = life });
            }
            else
            {
                Game.Instance.NewTurnEvent -= UnderContructionProgress;
            }
        }
    }
}
