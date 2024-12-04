using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class BiletForAllView
    {
        public int BiletID { get; set; }
        public decimal Cena { get; set; }
        public string TypBiletu {  get; set; }
        public string Opis { get; set; }
        public string FilmTytul { get; set; }
    }
}
