using System;
using System.ComponentModel;
using WarGame.Utils;

namespace WarGame.Models.Units
{
    public abstract class AbstractUnit : AbstractBuildable, INotifyPropertyChanged
    {

        private Point position;

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

        

        public int Life
        {
            get
            {
                return base.Life;
            }

            set
            {
                base.Life = value;
                OnPropertyChanged("Life");
            }
        }

      
        #endregion

        public AbstractUnit()
        {
        }

        public AbstractUnit(int y, int x, int life)
        {
            Position = new Point(x,y);
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
