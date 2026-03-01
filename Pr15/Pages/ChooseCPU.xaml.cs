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
        public ChooseCPU()
        {
            InitializeComponent();
            List<cpu> cpus = Core.Context.cpu.ToList();
            List<Computer> computers = new List<Computer>();
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

        }
    }
}
