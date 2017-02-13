using Curs28WPF.ViewModels;
using System.Windows;

namespace Curs28WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MapVM mapVM;

        public MainWindow()
        {
            InitializeComponent();
            Init();
        }

        internal MapVM MapVM
        {
            get
            {
                return mapVM;
            }

            set
            {
                mapVM = value;
            }
        }

        public void Init()
        {
            MapVM = new MapVM();
            //Farms = new ObservableCollection<FarmVM>();
            //FarmsLV.ItemsSource = Farms;
            //FarmsLVItemsControl.ItemsSource = Farms;
           // myFarm = new FarmVM();
            //Farm1.DataContext = myFarm;
        }
       
        private void btnNewFarm_Click(object sender, RoutedEventArgs e)
        {
           // farms.Add(new FarmVM());
           // myFarm.X++;
        }
    }
}
