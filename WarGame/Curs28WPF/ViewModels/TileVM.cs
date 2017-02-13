using System.ComponentModel;
using WarGame.Models;
using WarGame.Models.Resources;

namespace Curs28WPF.ViewModels
{
    class TileVM: INotifyPropertyChanged
    {
        private Tile tile;

        public event PropertyChangedEventHandler PropertyChanged;

        public TileVM()
        {
            Tile = new Tile();
        }

        public TileVM(Tile tile)
        {
            this.Tile = tile;
        }


        public Tile Tile
        {
            get
            {
                return tile;
            }

            private set
            {
                tile = value;
            }
        }

        public Resource Resource
        {
            get
            {
                return Tile.Resource;
            }
            set
            {
                Tile.Resource = value;
                NotifyPropertyChanged(nameof(Resource));
            }
        }

        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
