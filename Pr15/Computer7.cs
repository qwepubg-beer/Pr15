using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr15
{
    internal class Computer7
    {
        public storagedevice device {  get; set; }
        public storagedeviceinterface storagedeviceinterface { get; set; }
        public storagedevicetype storagedevicetype { get; set; }
        public basepart basepartdevice { get; set; }
        public string name { get; set; }
        public Computer7(storagedevice device)
        {
            this.device = device;
            basepart g = Core.Context.basepart.First(u => u.id == device.id);
            storagedeviceinterface si = Core.Context.storagedeviceinterface.First(u => u.id == device.storagedeviceinterfaceid);
            storagedevicetype st = Core.Context.storagedevicetype.First(u => u.id == device.storagedevicetypeid);
            basepartdevice = g;
            storagedeviceinterface=si;
            storagedevicetype=st;   
            name = $"{device.capacity}, {storagedevicetype.name}, {basepartdevice.name} [{storagedeviceinterface.name}]";
        }
    }
}
