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
    /// Логика взаимодействия для EndPage.xaml
    /// </summary>
    public partial class EndPage : Page
    {
        public EndPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Name.Text.Length > 0 && Autor.Text.Length>0)
            {
                assembly newa = new assembly
                {
                    name = Name.Text,
                    author = Autor.Text
                };
                Core.Context.assembly.Add(newa);
                Core.Context.SaveChanges();
                assembly edit = Core.Context.assembly.FirstOrDefault(u => u==newa);
                partassembly ps = new partassembly
                {
                    partid = MainStaticClass.ram.basepartram.id,
                    assemblyid = edit.id
                };
                Core.Context.partassembly.Add(ps);
                Core.Context.SaveChanges();
                partassembly ps2 = new partassembly
                {
                    partid = MainStaticClass.cpu.basepartCPU.id,
                    assemblyid = edit.id
                };
                Core.Context.partassembly.Add(ps2);
                Core.Context.SaveChanges();
                partassembly ps3 = new partassembly
                {
                    partid = MainStaticClass.mother.basepartmotherboard.id,
                    assemblyid = edit.id
                };
                Core.Context.partassembly.Add(ps3);
                Core.Context.SaveChanges();
                partassembly ps4 = new partassembly
                {
                    partid = MainStaticClass.gpu.basepartgpu.id,
                    assemblyid = edit.id
                };
                Core.Context.partassembly.Add(ps4);
                Core.Context.SaveChanges();
                partassembly ps5 = new partassembly
                {
                    partid = MainStaticClass.storage.basepartdevice.id,
                    assemblyid = edit.id
                };
                Core.Context.partassembly.Add(ps5);
                Core.Context.SaveChanges();
                partassembly ps6 = new partassembly
                {
                    partid = MainStaticClass.storage.basepartdevice.id,
                    assemblyid = edit.id
                };
                Core.Context.partassembly.Add(ps6);
                Core.Context.SaveChanges();
                partassembly ps7 = new partassembly
                {
                    partid = MainStaticClass.ram.basepartram.id,
                    assemblyid = edit.id
                };
                Core.Context.partassembly.Add(ps7);
                Core.Context.SaveChanges();
                partassembly ps8 = new partassembly
                {
                    partid = MainStaticClass.cooler.basepartcooler.id,
                    assemblyid = edit.id
                };
                Core.Context.partassembly.Add(ps8);
                Core.Context.SaveChanges();
                MessageBox.Show("Ваша сборка была опубликована!");

            }
        }

        }
    }
}
