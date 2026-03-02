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
    /// Логика взаимодействия для ChooseCase.xaml
    /// </summary>
    public partial class ChooseCase : Page
    {
        List<Computer4> computers = new List<Computer4>();
        public ChooseCase()
        {
            InitializeComponent();
            List<@case> cases = Core.Context.@case.ToList();
            foreach (@case m in cases)
            {
                basepart basep = Core.Context.basepart.First(u => u.id == m.id);
                casesize sock = Core.Context.casesize.First(u => u.id == m.sizeid);
                Computer4 mypc = new Computer4(m, basep, sock);
                computers.Add(mypc);
            }
            CaseList.ItemsSource = computers;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CaseList.SelectedItem != null)
            {
                MainStaticClass.korpus = (Computer4)CaseList.SelectedItem;
                MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
                mainWindow.MainFrame.Navigate(new MainPage());
            }
        }

        private void CaseList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CaseList.ItemsSource = computers.Where(t => t.basepartcase.name.Contains(TextSearch.Text)).ToList();
        }
    }
}
