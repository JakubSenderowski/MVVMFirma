using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class PromocjaForAllView
    {
        public int PromocjaID { get; set; }
        public string Opis { get; set; }
        public string TypBiletu { get; set; } //Tutaj odnosimy się do tabeli Bilet! <--- (ZAPAMIĘTAJ)
        public decimal Rabat { get; set; }
        public DateTime DataRozpoczecia { get; set; }
        public DateTime DataZakonczenia { get; set; }   

        public string Tytul {  get; set; }  //Tutaj odnosimy się do tabeli Film! <--- (ZAPAMIĘTAJ)
    }
}
