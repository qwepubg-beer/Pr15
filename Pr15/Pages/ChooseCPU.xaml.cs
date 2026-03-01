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
    /// Логика взаимодействия для ChooseCPU.xaml
    /// </summary>
    public partial class ChooseCPU : Page
    {
        List<Computer> computers = new List<Computer>();
        public ChooseCPU()
        {
            InitializeComponent();
            List<cpu> cpus = Core.Context.cpu.ToList();
            foreach (cpu cpu in cpus)
            {
                basepart basep = Core.Context.basepart.First(u => u.id==cpu.id);
                socket sock = Core.Context.socket.First(u => u.id == cpu.socketid);
                Computer mypc = new Computer(cpu, basep, sock);
                computers.Add(mypc);
            }
            CPUList.ItemsSource = computers;    

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CPUList.SelectedItem != null) 
            {
                MainStaticClass.cpu = (Computer)CPUList.SelectedItem;
                MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
                mainWindow.MainFrame.Navigate(new MainPage());
            }
        }

        private void CPUList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CPUList.ItemsSource = computers.Where(t => t.basepartCPU.name.Contains(TextSearch.Text)).ToList();
        }
    }
}
