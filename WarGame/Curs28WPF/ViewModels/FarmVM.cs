using Curs28WPF.Models;
using System.ComponentModel;

namespace Curs28WPF.ViewModels
{
    public class FarmVM: INotifyPropertyChanged
    {
        private Farm farm;

        public event PropertyChangedEventHandler PropertyChanged;

        public FarmVM()
        {
            farm = new Farm();
        }

        public FarmVM(Farm farm)
        {
            this.farm = farm;
        }

        public int X
        {
            get { return farm.X; }
            set { farm.X = value;
                NotifyPropertyChanged(nameof(X));
            }
        }
        public int Y
        {
            get { return farm.Y; }
            set { farm.Y = value;
                NotifyPropertyChanged(nameof(Y));
            }
        }
        public int Life
        {
            get { return farm.Life; }
            set { farm.Life = value;
                NotifyPropertyChanged(nameof(Life));

            }
        }

        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
