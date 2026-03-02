using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Pr15
{
    internal class Computer4
    {
        public @case korpus {  get; set; }
        public basepart basepartcase { get; set; }  
        public casesize casesize { get; set; }
        public string name { get; set; }
        public List<formfactor> formfactor { get; set; }=new List<formfactor>();    
        public Computer4(@case korpus, basepart basepartcase, casesize casesize)
        {
            this.korpus = korpus;
            this.basepartcase = basepartcase;
            this.casesize = casesize;
            List<boardformfactorcase> formfactor2 = Core.Context.boardformfactorcase.Where(u => u.caseid == korpus.id).ToList();
            
            string factors = "";
            foreach (boardformfactorcase b in formfactor2)
            {
                formfactor f = Core.Context.formfactor.Where(u => u.id == b.formfactorid).FirstOrDefault();
                formfactor.Add(f);
                factors += $"{f.name}, ";
            }
            name = $"Корпус {basepartcase.name } [{casesize.name}, {factors}, {korpus.expansionslots}*Диск,{korpus.fans}*вентилятор]";
        }
    }
}
