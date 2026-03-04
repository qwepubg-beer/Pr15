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
    /// Логика взаимодействия для ChooseCuler.xaml
    /// </summary>
    public partial class ChooseCuler : Page
    {
        List<Computer6> computers = new List<Computer6>();

        public ChooseCuler()
        {
            InitializeComponent();
           
            List<processorcooler> coolers = Core.Context.processorcooler.ToList();
            foreach (processorcooler m in coolers)
            {
                Computer6 g = new Computer6(m);
                computers.Add(g);
            } 
            if (MainStaticClass.cpu != null)
            {
                if (MainStaticClass.mother != null)
                {
                    computers = computers.Where(u => u.sockets.Contains(MainStaticClass.mother.socketmotherboard)).ToList();
                }
                computers = computers.Where(u => u.sockets.Contains(MainStaticClass.cpu.socketCPU)).ToList();
            }
            CulerList.ItemsSource = computers;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CulerList.SelectedItem != null)
            {
                MainStaticClass.cooler = (Computer6)CulerList.SelectedItem;
                MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
                mainWindow.MainFrame.Navigate(new MainPage());
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CulerList.ItemsSource = computers.Where(t => t.basepartcooler.name.Contains(TextSearch.Text)).ToList();
        }
    }
}
