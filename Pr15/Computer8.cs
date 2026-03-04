using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr15
{
    internal class Computer8
    {
        public ram ram { get; set; }
        public basepart basepartram { get; set; }
        public memorytype memorytype {get; set;}
        public string name { get; set; }   
        public Computer8(ram ram)
        {
            this.ram = ram;
            basepart g = Core.Context.basepart.First(u => u.id == ram.id);
            basepartram = g;
            memorytype m = Core.Context.memorytype.First(u => u.id == ram.memorytypeid);
            memorytype = m;
            name = $"Оперативная память {basepartram.name} {ram.capacity} ГБ [{memorytype.name}, {ram.count} шт, {ram.ghz} МГц, {ram.timings}]";

        }
    }
}
