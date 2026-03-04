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
            if (MainStaticClass.cpu != null) 
            {
                if(MainStaticClass.ram != null)
                {
                     computers = computers.Where(u => u.memorytypemotherboard.id == MainStaticClass.ram.memorytype.id).ToList();
                }
                computers = computers.Where(u => u.socketmotherboard.id == MainStaticClass.cpu.socketCPU.id).ToList();
                
            }
            foreach (motherboard m in motherboards)
            {
                basepart basep = Core.Context.basepart.First(u => u.id == m.id);
                socket sock = Core.Context.socket.First(u => u.id == m.socketid);
                memorytype memorytype = Core.Context.memorytype.First(u => u.id == m.memorytypeid);
                formfactor formfactor = Core.Context.formfactor.First(u => u.id == m.formfactorid);
                Computer2 mypc = new Computer2(m, basep, sock, memorytype, formfactor);
                computers.Add(mypc);
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
