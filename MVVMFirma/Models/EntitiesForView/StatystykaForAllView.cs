using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public  class StatystykaForAllView
    {
        public int StatystykiID { get; set; }
        public DateTime Data { get; set; }
        public int LiczbaSprzedanychBiletow { get; set; }
        public decimal LacznyPrzychod {  get; set; }

        public string FilmTytul {  get; set; }

        public int SalaLiczbaMiejsc {  get; set; }
    }
}
