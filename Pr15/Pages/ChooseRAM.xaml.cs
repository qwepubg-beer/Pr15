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
    /// Логика взаимодействия для ChooseRAM.xaml
    /// </summary>
    public partial class ChooseRAM : Page
    {
        List<Computer8> computers = new List<Computer8>();
        public ChooseRAM()
        {
            InitializeComponent();
            List<ram> rams = Core.Context.ram.ToList();
            foreach (ram r in rams)
            {
                Computer8 g = new Computer8(r);
                computers.Add(g);
            }
            RAMList.ItemsSource = computers;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (RAMList.SelectedItem != null)
            {
                MainStaticClass.ram = (Computer8)RAMList.SelectedItem;
                MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
                mainWindow.MainFrame.Navigate(new MainPage());
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RAMList.ItemsSource = computers.Where(t => t.basepartram.name.Contains(TextSearch.Text)).ToList();
        }
    }
}
