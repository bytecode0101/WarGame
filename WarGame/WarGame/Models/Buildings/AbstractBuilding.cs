using System;
using System.Collections.Generic;
using System.ComponentModel;
using WarGame.Models.Capabilities;
using WarGame.Models.Events;

namespace WarGame.Models.Buildings
{
    public abstract class AbstractBuilding : AbstractBuildable, INotifyPropertyChanged
    {

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        #endregion

        #region Constructors

        public AbstractBuilding() { }

        public AbstractBuilding(int y, int x, int life)
        {
            Position = new Point(x, y);
            Life = life;
        }

        #endregion

        #region Private fields

        private Point position;
        private Dictionary<Type, AbstractBuildCapability> buildCapabilities = new Dictionary<Type, AbstractBuildCapability>();
        private Dictionary<Type, AbstractTrainCapability> trainCapabilities = new Dictionary<Type, AbstractTrainCapability>();

        #endregion

        #region Properties

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

        public Dictionary<Type, AbstractBuildCapability> BuildCapabilities
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

        public Dictionary<Type, AbstractTrainCapability> TrainCapabilities
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

        #endregion

        #region Public Methods

        #endregion

    }
}
