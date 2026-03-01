using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr15
{
    internal class Computer2
    {
       public motherboard motherboard {  get; set; }
       public basepart basepartmotherboard { get; set; }
       public socket socketmotherboard { get; set; }
        public memorytype memorytypemotherboard { get; set; }
        public formfactor formfactormotherboard { get; set; }
        public string name { get; set; }

        public Computer2(motherboard motherboard, basepart basepartmotherboard, socket socketmotherboard, memorytype memorytypemotherboard, formfactor formfactormotherboard)
        {
            this.motherboard = motherboard;
            this.basepartmotherboard = basepartmotherboard;
            this.socketmotherboard = socketmotherboard;
            this.memorytypemotherboard = memorytypemotherboard;
            this.formfactormotherboard = formfactormotherboard;
            name = $"Материнская плата {basepartmotherboard.name} [{socketmotherboard.name}, {motherboard.memoryslots}x{memorytypemotherboard.name}, {motherboard.pcislots}xPCI, {motherboard.sataports}xSATA, {formfactormotherboard.name}]";
        }
    }
}
