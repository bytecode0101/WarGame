using System;
using System.Collections.Generic;
using System.ComponentModel;
using WarGame.Models.Capabilities;
using WarGame.Models.Events;

namespace WarGame.Models.Buildings
{
    public abstract class AbstractBuilding : AbstractBuildable, INotifyPropertyChanged
    {


        private Point position;
        protected List<AbstractBuildCapability> buildCapabilities = new List<AbstractBuildCapability>();
        protected List<AbstractTrainCapability> trainCapabilities = new List<AbstractTrainCapability>();

        //public int Life
        //{
        //    get
        //    {
        //        return life;
        //    }

        //    set
        //    {
        //        life = value;
        //    }
        //}
       

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
            Position = new Point(x, y);
            Life = life;
        }
        #endregion

        public void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }






        public abstract AbstractBuilding Upgrade();
    }
}
