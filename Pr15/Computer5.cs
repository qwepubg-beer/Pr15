using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr15
{
    internal class Computer5
    {
        public gpu gpu {  get; set; }
        public basepart basepartgpu { get; set; }
        public List<videoconnector> videoconnector { get; set; }=new List<videoconnector>();    
        public string name { get; set; }
        public Computer5(gpu gpu)
        {
            this.gpu = gpu;
            basepart g = Core.Context.basepart.First(u => u.id == gpu.id);
            List<videoconnectorgpu> vc  = Core.Context.videoconnectorgpu.Where(u=> u.gpuid==gpu.id).ToList();
            basepartgpu = g;
            string connector = "";
            foreach(videoconnectorgpu v in vc)
            {
                videoconnector con = Core.Context.videoconnector.First(u => u.id==v.videoconnectorid);
                videoconnector.Add(con);
                connector += $"{con.name} ";
            }
            name = $"Видеокарта {basepartgpu.name} [GPU {gpu.chipfrequency} МГц, {gpu.videomemory} ГБ, {gpu.memorybus} бит, {connector}]";
        }
    }
}
