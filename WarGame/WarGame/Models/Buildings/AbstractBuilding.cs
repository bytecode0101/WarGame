﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using WarGame.Models.Capabilities;


namespace WarGame.Models.Buildings
{
    public abstract class AbstractBuilding : INotifyPropertyChanged
    {
        private int life;
        private Guid id;
        private Point position;
        protected List<AbstractBuildCapability> buildCapabilities = new List<AbstractBuildCapability>();
        protected List<AbstractTrainCapability> trainCapabilities = new List<AbstractTrainCapability>();

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

        public abstract AbstractBuilding Upgrade();
    }
}