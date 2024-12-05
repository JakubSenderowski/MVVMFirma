using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class RepertuarForAllView
    {
        public int RepertuarID { get; set; }
        public DateTime Data {  get; set; }
        public string GodzinySeansow { get; set; }
       
        public int NumerSali {  get; set; }

        public string TytulFilmu { get; set; }
    }
}
