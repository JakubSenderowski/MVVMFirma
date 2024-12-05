using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class RezerwacjaForAllView
    {
        public int RezerwacjaID { get; set; }
        public string KlientImie { get; set; }
        public string KlientNazwisko { get; set; }
        public string KlientMail { get; set; }

        public string KlientNumer {  get; set; }
       

        public DateTime DataRezerwacji { get; set; }
        public DateTime DataSeansu {  get; set; }
        public int LiczbaBiletow {  get; set; }

        public string StatusRezerwacji { get; set; }
    }
}
