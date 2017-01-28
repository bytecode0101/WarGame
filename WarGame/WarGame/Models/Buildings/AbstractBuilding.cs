using System;
using System.Collections.Generic;
using System.ComponentModel;
using WarGame.Models.Capabilities;
using WarGame.Models.Events;

namespace WarGame.Models.Buildings
{
    public abstract class AbstractBuilding : INotifyPropertyChanged
    {
        private int life;
        private Guid id;
        private Point position;
        protected List<AbstractBuildCapability> buildCapabilities = new List<AbstractBuildCapability>();
        protected List<AbstractTrainCapability> trainCapabilities = new List<AbstractTrainCapability>();
        protected int progress;
        #region Events

        public event UnderConstruction UnderConstructionEvent;

        #endregion

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
        public Guid Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public Point Position
        {
            get
            {
                return position;
            }

            set
            {
                position = value;
            }
        }

        public List<AbstractBuildCapability> BuildCapabilities
        {
            get
            {
                return buildCapabilities;
            }

            set
            {
                buildCapabilities = value;
            }
        }

        public List<AbstractTrainCapability> TrainCapabilities
        {
            get
            {
                return trainCapabilities;
            }

            set
            {
                trainCapabilities = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #region Constructors
        public AbstractBuilding(int y, int x, int life)
        {
            Position = new Point();
            Position.Y = y;
            Position.X = x;
            Life = life;
        }
        #endregion

        public void OnPropertyChanged(string propName)
        {
            if (PropertyChanged!=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        public void StartBuilding()
        {
            Game.Instance.NewTurnEvent += Instance_NewTurnEvent;
        }

        private void Instance_NewTurnEvent(Game sender, NewTurnArgs args)
        {
            if (life < 100)
            {
                life += progress;
                UnderConstructionEvent?.Invoke(sender, new ContructionArgs() { Percentage = life });
            }
        }

        public abstract AbstractBuilding Upgrade();
    }
}
