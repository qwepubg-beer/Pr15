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
    /// Логика взаимодействия для ChooseGPU.xaml
    /// </summary>
    public partial class ChooseGPU : Page
    {
        List<Computer5> computers = new List<Computer5>();
        public ChooseGPU()
        {
            InitializeComponent();
            List<gpu> gpus = Core.Context.gpu.ToList();
            foreach (gpu m in gpus)
            {
                Computer5 g= new Computer5(m);
                computers.Add(g);
            }
            GPUList.ItemsSource = computers;
        }

        private void CPUList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (GPUList.SelectedItem != null)
            {
                MainStaticClass.gpu = (Computer5)GPUList.SelectedItem;
                MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
                mainWindow.MainFrame.Navigate(new MainPage());
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            GPUList.ItemsSource = computers.Where(t => t.basepartgpu.name.Contains(TextSearch.Text)).ToList();
        }
    }
}
