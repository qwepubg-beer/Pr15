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
        public Sborki()
        {
            InitializeComponent();
        }
        public void sb(List<partassembly> list)
        {
            string name = string.Empty;
            foreach (partassembly partassembly in list)
            {
                basepart removeUser = basepart.(u => u.Клиент.Contains("Гордов"));
            }
        }
    }
}
