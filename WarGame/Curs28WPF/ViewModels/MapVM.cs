using System.ComponentModel;
using WarGame.Models;
using WarGame.Models.Resources;
namespace Curs28WPF.ViewModels
{
    class MapVM: INotifyPropertyChanged
    {
        private Map map;

        public event PropertyChangedEventHandler PropertyChanged;

        public MapVM()
        {
            map = new Map();
        }

        public MapVM(Map map)
        {
            this.map = map;
        }

        public Tile[,] Tiles
        {
            get
            {
                return map.Tiles;
            }

            set
            {
                map.Tiles = value;
                NotifyPropertyChanged(nameof(Tiles));
            }
        }

        public int NumberOfRows
        {
            get
            {
                return map.NumberOfRows;
            }

            set
            {
                map.NumberOfRows = value;
                NotifyPropertyChanged(nameof(NumberOfRows));
            }
        }

        public int NumberOfColumns
        {
            get
            {
                return map.NumberOfColumns;
            }

            set
            {
                map.NumberOfColumns = value;
                NotifyPropertyChanged(nameof(NumberOfColumns));

            }
        }

        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
