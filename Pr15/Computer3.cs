using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr15
{
    internal class Computer3
    {
        public string name {  get; set; }
        public powersupply powersupply { get; set; }
        public basepart basepartpowersupply { get; set; }
        public certificate certificate { get; set; }    
        public fandimension fandimension { get; set; }
        public Computer3(powersupply powersupply, certificate certificate, fandimension fandimension, basepart basepartpowersupply)
        {
            this.powersupply = powersupply;
            this.certificate = certificate;
            this.fandimension = fandimension;
            this.basepartpowersupply = basepartpowersupply;
            this.name = $"Блок питания {basepartpowersupply.name} [{powersupply.power} Вт, {certificate.name}, вентилятор {fandimension.name}]";
        }
    }
}
