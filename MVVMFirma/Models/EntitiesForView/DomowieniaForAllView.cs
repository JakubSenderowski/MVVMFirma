using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class DomowieniaForAllView
    {
        public int IdDomowienia {  get; set; }
        public string TypBiletu { get; set; }
        public string NazwaTowaru { get; set; }

        public int? Ilosc {  get; set; }

        public decimal? Cena { get; set; }
    }
}
