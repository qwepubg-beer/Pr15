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
                Case.Text = $"Выбрано: {MainStaticClass.korpus.basepartcase.name}";
                Price.Text = $"Цена : {Pr()}";
            }
            else
            {
                Case.Text = $"Не выбрано";
            }
            if (MainStaticClass.ram != null)
            {
               RAM.Text = $"Выбрано: {MainStaticClass.ram.basepartram.name}";
                Price.Text = $"Цена : {Pr()}";
            }
            else
            {
                RAM.Text = $"Не выбрано";
            }
            if (MainStaticClass.storage != null)
            {
                DISK.Text = $"Выбрано: {MainStaticClass.storage.basepartdevice.name}";
                Price.Text = $"Цена : {Pr()}";
            }
            else
            {
                DISK.Text = $"Не выбрано";
            }
            if (MainStaticClass.cooler != null)
            {
                COOLER.Text = $"Выбрано: {MainStaticClass.cooler.basepartcooler.name}";
                Price.Text = $"Цена : {Pr()}";
            }
            else
            {
                COOLER.Text = $"Не выбрано";
            }
            if (MainStaticClass.gpu != null)
            {
                GPU.Text = $"Выбрано: {MainStaticClass.gpu.basepartgpu.name}";
                Price.Text = $"Цена : {Pr()}";
            }
            else
            {
                GPU.Text = $"Не выбрано";
            }

        }
        public decimal Pr()
        {
            decimal a= (MainStaticClass.cpu != null) ? MainStaticClass.cpu.basepartCPU.price: 0;
            a = (MainStaticClass.mother != null) ? MainStaticClass.mother.basepartmotherboard.price+a : a;
            a = (MainStaticClass.power != null) ? MainStaticClass.power.basepartpowersupply.price + a : a;
            a = (MainStaticClass.korpus != null) ? MainStaticClass.korpus.basepartcase.price + a : a;
            a = (MainStaticClass.gpu != null) ? MainStaticClass.gpu.basepartgpu.price + a : a;
            a = (MainStaticClass.cooler != null) ? MainStaticClass.cooler.basepartcooler.price + a : a;
            a = (MainStaticClass.storage != null) ? MainStaticClass.storage.basepartdevice.price + a : a;
            a = (MainStaticClass.ram != null) ? MainStaticClass.ram.basepartram.price + a : a;
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
            if (MainStaticClass.mother != null)
            {
                MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
                mainWindow.MainFrame.Navigate(new ChooseCase());
            }
            else
            {
                MessageBox.Show("Нужна мать!");
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.MainFrame.Navigate(new ChooseGPU());
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if(MainStaticClass.cpu !=null)
            { 
                MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
                mainWindow.MainFrame.Navigate(new ChooseCuler()); 
            }
            else
            {
                MessageBox.Show("Выбер камень!");
            }
           
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.MainFrame.Navigate(new ChooseDisk());
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.MainFrame.Navigate(new ChooseRAM());
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            bool comp1=MainStaticClass.cpu != null;
            bool comp2 = MainStaticClass.storage != null;
            bool comp3 = MainStaticClass.gpu != null;
            bool comp4 = MainStaticClass.cooler != null;
            bool comp5 = MainStaticClass.power != null;
            bool comp6 = MainStaticClass.korpus != null;
            bool comp7 = MainStaticClass.ram != null;
            bool comp8 = MainStaticClass.mother != null;
            if(comp1 && comp2 && comp3 && comp4 && comp5 && comp6 && comp7 && comp8)
            {
                if (MainStaticClass.cpu.cpu.thermalpower + MainStaticClass.gpu.gpu.recommendpower + 50 > MainStaticClass.power.powersupply.power)
                {
                    MessageBox.Show("Вам нехватает мощности, выбирите другой блок питания");
                    MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
                    mainWindow.MainFrame.Navigate(new EndPage());
                }

            }
            else
            {
                MessageBox.Show("Выбирите все основные компоненты!");
            }

   
        }
    }
}
