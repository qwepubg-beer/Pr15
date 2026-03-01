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

namespace Pr15.Pages
{
    /// <summary>
    /// Логика взаимодействия для ChoosePower.xaml
    /// </summary>
    public partial class ChoosePower : Page
    {
        List<Computer3> computers = new List<Computer3>();
        public ChoosePower()
        {
            InitializeComponent();
            List<powersupply> motherboards = Core.Context.powersupply.ToList();
            foreach (powersupply m in motherboards)
            {
                basepart basep = Core.Context.basepart.First(u => u.id == m.id);
                certificate cert = Core.Context.certificate.First(u => u.id == m.certificationid);
                fandimension fandimension = Core.Context.fandimension.First(u => u.id == m.fandimensionid);
                Computer3 mypc = new Computer3(m, cert, fandimension, basep);
                computers.Add(mypc);
            }
            PowerList.ItemsSource = computers;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (PowerList.SelectedItem != null)
            {
                MainStaticClass.power = (Computer3)PowerList.SelectedItem;
                MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
                mainWindow.MainFrame.Navigate(new MainPage());
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PowerList.ItemsSource = computers.Where(t => t.basepartpowersupply.name.Contains(TextSearch.Text)).ToList();
        }
    }
}
