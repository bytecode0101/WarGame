using System;
using System.ComponentModel;
using WarGame.Utils;

namespace WarGame.Models.Units
{
    public abstract class Unit : Serializable, INotifyPropertyChanged
    {
        private Guid id;
        private int life;
        private Point position;
        private int capacity;

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

        public int Life
        {
            get
            {
                return life;
            }

            set
            {
                life = value;
                OnPropertyChanged("Life");
            }
        }

        public int Capacity
        {
            get
            {
                return capacity;
            }

            set
            {
                capacity = value;
            }
        }
        #endregion

        public Unit(int y, int x, int life)
        {
            Position = new Point();
            Position.Y = y;
            Position.X = x;
            Life = life;
        }
        public abstract void GatherResource(Tile argTile);
        public abstract void Attack();
        public abstract void Move(Point destination);

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
