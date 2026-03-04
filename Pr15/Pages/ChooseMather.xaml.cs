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
    /// Логика взаимодействия для ChooseMather.xaml
    /// </summary>
    public partial class ChooseMather : Page
    {
        List<Computer2> computers = new List<Computer2>();
        public ChooseMather()
        {
            InitializeComponent();
            List<motherboard> motherboards = Core.Context.motherboard.ToList(); 
            foreach (motherboard m in motherboards)
            {
                Computer2 mypc = new Computer2(m);
                computers.Add(mypc);
            }
            if (MainStaticClass.cpu != null) 
            {
                computers = computers.Where(u => u.socketmotherboard.id == MainStaticClass.cpu.socketCPU.id).ToList();
            }
            if (MainStaticClass.ram != null)
            {
                computers = computers.Where(u => u.memorytype == MainStaticClass.ram.memorytype).ToList();
            }
            MotherList.ItemsSource = computers;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MotherList.SelectedItem != null)
            {
                MainStaticClass.mother = (Computer2)MotherList.SelectedItem;
                MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
                mainWindow.MainFrame.Navigate(new MainPage());
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MotherList.ItemsSource = computers.Where(t => t.basepartmotherboard.name.Contains(TextSearch.Text)).ToList();
        }
    }
}
