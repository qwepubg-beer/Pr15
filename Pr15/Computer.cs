using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr15
{
    public class Computer
    {
        public cpu cpu {  get; set; }
        public basepart basepartCPU { get; set; }
        public socket socketCPU { get; set; }   
        public string Cpuinfo { get; set; }
        public Computer(cpu cpu, basepart basepartCPU, socket socketCPU)
        {
            this.cpu = cpu;
            this.basepartCPU = basepartCPU;
            this.socketCPU = socketCPU;
            Cpuinfo = $"{basepartCPU.name} [{socketCPU.name}, {cpu.numberofcores} x {cpu.basecorefrequency} ГГц, L3 - {cpu.cachel3} МБ, Igpu: {cpu.hasigpu}, TDP {cpu.thermalpower} Вт]";
            
        }
    }
}
