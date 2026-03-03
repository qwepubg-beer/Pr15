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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            if (MainStaticClass.cpu != null) {
                CPU.Text = $"Выбрано: {MainStaticClass.cpu.basepartCPU.name}";
                Price.Text = $"Цена : {Pr()}";
            }
            else
            {
                CPU.Text = $"Не выбрано";
            }
            if (MainStaticClass.mother != null)
            {
                Motherboard.Text = $"Выбрано: {MainStaticClass.mother.basepartmotherboard.name}";
                Price.Text = $"Цена : {Pr()}";
            }
            else
            {
                Motherboard.Text = $"Не выбрано";
            }
            if (MainStaticClass.power != null)
            {
                Power.Text = $"Выбрано: {MainStaticClass.power.basepartpowersupply.name}";
                Price.Text = $"Цена : {Pr()}";
            }
            else
            {
                Power.Text = $"Не выбрано";
            }
            if (MainStaticClass.korpus != null)
            {
                Case.Text = $"Выбрано: {MainStaticClass.power.basepartpowersupply.name}";
                Price.Text = $"Цена : {Pr()}";
            }
            else
            {
                Case.Text = $"Не выбрано";
            }
        }
        public decimal Pr()
        {
            decimal a= (MainStaticClass.cpu != null) ? MainStaticClass.cpu.basepartCPU.price: 0;
            a = (MainStaticClass.mother != null) ? MainStaticClass.mother.basepartmotherboard.price+a : a;
            a = (MainStaticClass.power != null) ? MainStaticClass.power.basepartpowersupply.price + a : a;
            a = (MainStaticClass.korpus != null) ? MainStaticClass.korpus.basepartcase.price + a : a;
            a = (MainStaticClass.gpu != null) ? MainStaticClass.gpu.basepartgpu.price + a : a;
            return Math.Round(a);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.MainFrame.Navigate(new ChooseCPU());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.MainFrame.Navigate(new ChooseMather());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.MainFrame.Navigate(new ChoosePower());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.MainFrame.Navigate(new ChooseCase());
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.MainFrame.Navigate(new ChooseGPU());
        }
    }
}
