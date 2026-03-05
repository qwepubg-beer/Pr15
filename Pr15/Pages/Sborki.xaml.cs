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
    /// Логика взаимодействия для Sborki.xaml
    /// </summary>
    public partial class Sborki : Page
    {
        public List<Sbor> sber=new List<Sbor>(); 
        public Sborki()
        {
            InitializeComponent();
            List<assembly> rs = Core.Context.assembly.ToList();
              
            foreach (assembly asem in rs)
            {
                Sbor sbor=new Sbor(asem);
                sber.Add(sbor);
            }
            SborkaList.ItemsSource = sber;
        }
        public class Sbor
        {
            public assembly assembly {  get; set; }
            public string name { get; set; }
            public Sbor(assembly assembly) 
            {
                this.assembly = assembly;
                List<partassembly> list = Core.Context.partassembly.Where(u => u.assemblyid==assembly.id).ToList();
                foreach (partassembly partassembly in list)
                {
                    basepart basep = Core.Context.basepart.First(u => u.id==partassembly.partid);
                    name += $"{basep.name}, ";
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Поздравляю с покупкой");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SborkaList.ItemsSource = sber.Where(t => t.assembly.name.Contains(TextSearch.Text)).ToList();
        }
    }
}
