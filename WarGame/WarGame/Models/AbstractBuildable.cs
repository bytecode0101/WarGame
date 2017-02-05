using WarGame.Models.Events;

namespace WarGame.Models
{
    public abstract class AbstractBuildable
    {
        #region Events
        public event UnderConstruction UnderConstructionEvent;
        public event UnderAttack UnderAttackEvent;
        #endregion

        #region Private Fields

        private static int numberOfBuildables = 0;
        private int life;
        protected int progress; 

        #endregion

        public int Id { get; set; }

        public int Life
        {
            get
            {
                return life;
            }

            set
            {
                life = value;
            }
        }

        /// <summary>
        /// Subscribe to game new turn event
        /// </summary>
        public void StartBuilding()
        {
            Game.Instance.NewTurnEvent += UnderContructionProgress;
        }

        /// <summary>
        /// Under attack. Invoke under attack event.
        /// </summary>
        /// <param name="strength"></param>
        public void Attack(int strength)
        {
            if (Life > 0)
            {
                Life -= strength;
                UnderAttackEvent?.Invoke(this, new UnderAttackArgs());
            }

        }

        protected virtual void UnderContructionProgress(Game sender, NewTurnArgs args)
        {
            if (Life < 100)
            {
                Life += progress;
                UnderConstructionEvent?.Invoke(this, new ConstructionArgs() { Percentage = Life });
            }
            else
            {
                Game.Instance.NewTurnEvent -= UnderContructionProgress;
            }
        }

        private void UnderAttackProgress(Game sender, NewTurnArgs args)
        {

        }

        public AbstractBuildable()
        {
            Id = numberOfBuildables++;
        }
    }
}
