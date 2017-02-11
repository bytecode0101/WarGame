using Curs28WPF.ViewModels;
using System.Collections.ObjectModel;
using System.Windows;

namespace Curs28WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<FarmVM> farms;
        private FarmVM myFarm;

        public ObservableCollection<FarmVM> Farms
        {
            get
            {
                return farms;
            }

            set
            {
                farms = value;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            Farms = new ObservableCollection<FarmVM>();
            //FarmsLV.ItemsSource = Farms;
            FarmsLVItemsControl.ItemsSource = Farms;
           // myFarm = new FarmVM();
            //Farm1.DataContext = myFarm;
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = "hello world";
        }

        private void btnNewFarm_Click(object sender, RoutedEventArgs e)
        {
            farms.Add(new FarmVM());
           // myFarm.X++;
        }
    }
}
