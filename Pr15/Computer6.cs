using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Pr15
{
    internal class Computer6
    {
        public processorcooler processorcooler {  get; set; }
        public basepart basepartcooler { get; set; }  
        public fandimension fandimension { get; set; }  
        List<socket> sockets { get; set; } = new List<socket>();
        public string name { get; set; }
        public Computer6 (processorcooler processorcooler)
        {
            this.processorcooler = processorcooler;
            basepart g = Core.Context.basepart.First(u => u.id == processorcooler.id);
            basepartcooler = g;
            fandimension f = Core.Context.fandimension.First(u => u.id == processorcooler.fandimensionid);
            fandimension = f;
            string sock = "";
            List<socketprocessorcooler> vc = Core.Context.socketprocessorcooler.Where(u => u.processorcoolerid == processorcooler.id).ToList();
            foreach (socketprocessorcooler s in vc)
            {
                socket con = Core.Context.socket.First(u => u.id == s.socketid);
                sockets.Add(con);
                sock += $"{con.name} ";
            }
            name = $"Кулер для процессора {basepartcooler.name} [вентилятор - {fandimension.name} мм, до {processorcooler.maxspeed} об/мин, {processorcooler.noiselevel} дБ, {processorcooler.heatpipes} pin]";
        }

    }
}
