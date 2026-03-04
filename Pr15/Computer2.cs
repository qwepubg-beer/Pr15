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
       public memorytype memorytype { get; set; }
       public formfactor formfactormotherboard { get; set; }
       public string name { get; set; }

        public Computer2(motherboard motherboard)
        {
            basepart basep = Core.Context.basepart.First(u => u.id == motherboard.id);
            socket sock = Core.Context.socket.First(u => u.id == motherboard.socketid);
            memorytype memorytype = Core.Context.memorytype.First(u => u.id == motherboard.memorytypeid);
            formfactor formfactor = Core.Context.formfactor.First(u => u.id == motherboard.formfactorid);
            this.motherboard = motherboard;
            basepartmotherboard = basep;
            socketmotherboard = sock;
            this.memorytype = memorytype;
            formfactormotherboard = formfactor;
            name = $"Материнская плата {basepartmotherboard.name} [{socketmotherboard.name}, {motherboard.memoryslots}x{memorytype.name}, {motherboard.pcislots}xPCI, {motherboard.sataports}xSATA, {formfactormotherboard.name}]";
        }
    }
}
