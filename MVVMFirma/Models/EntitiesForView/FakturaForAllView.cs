using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
     //Klasa wzorowana jest na klasie faktura tylko zamiast kluczy obcych ma czytalne dla klienta pola.
     //Klucze obce będą zastąpione czytelnymi dla zwykłego człowieka danymi. 
    public class FakturaForAllView
    {
        public int IdFaktury{ get; set; }
        public string Numer { get; set; }
        public bool? CzyZatwierdzona { get; set; }
        public DateTime? DataWystawienia { get; set; }

        // Nip i nazwa zamiast klucza obcego IDKontrahenta <--- ! ! ! --->
        public string KontrahentNIP { get; set; }
        public string KontrahentNazwa { get; set; }

        public DateTime TerminPlatnosci { get; set; }

        //To jest pole zamiast klucza obcego IDSposobuPlatnosci
        public string SposobPlatnosciNazwa { get; set; }
        public int DostawcaID { get; set; }
    }
}
