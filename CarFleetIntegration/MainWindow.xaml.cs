using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarFleetIntegration
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Car car1 = new Car();
        Car car2 = new Car();

        Center center = new Center();

        public MainWindow()
        {
            InitializeComponent();

            car1.SubscribeToService(center);
            car2.SubscribeToService(center);

            center.SubscribeToFixCarErrors(car1);
            center.SubscribeToFixCarErrors(car2);
        }

        private void btnCar1_Click(object sender, RoutedEventArgs e)
        {
            car1.RunInCaseOfError();
        }

        private void btnCar2_Click(object sender, RoutedEventArgs e)
        {
            car2.RunInCaseOfError();
        }
    }
}
