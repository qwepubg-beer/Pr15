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
    /// Логика взаимодействия для ChooseDisk.xaml
    /// </summary>
    public partial class ChooseDisk : Page
    {
        List<Computer7> computers = new List<Computer7>();
        public ChooseDisk()
        {
            InitializeComponent();
            List<storagedevice> storages = Core.Context.storagedevice.ToList();
            foreach (storagedevice m in storages)
            {
                Computer7 g = new Computer7(m);
                computers.Add(g);
            }
            DiskList.ItemsSource = computers;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (DiskList.SelectedItem != null)
            {
                MainStaticClass.storage = (Computer7)DiskList.SelectedItem;
                MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
                mainWindow.MainFrame.Navigate(new MainPage());
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DiskList.ItemsSource = computers.Where(t => t.basepartdevice.name.Contains(TextSearch.Text)).ToList();
        }
    }
}
