using System;
using System.ComponentModel;

namespace WarGame.Models.Buildings
{
    public abstract class Building : INotifyPropertyChanged
    {
        private int life;
        private Guid id;
        private Point position;

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

        public event PropertyChangedEventHandler PropertyChanged;

        #region Constructors
        public Building(int y, int x, int life)
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
    }
}
