using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    internal class RaportB:DatabaseClass
    {
        #region Konstruktor
        public RaportB(KinoEntities db)
            : base(db) { }
        #endregion
        #region Funkcje biznesowe
        //Funckja oblicza  całkowitą kwotę sprzedaży za Dany tytuł filmu! <---!
        public List<String> RaportOkresowy(int FilmID, DateTime DataRozpoczecia, DateTime DataZakonczenia)
        {
            return (
                from promocje in db.Promocja
                where promocje.DataRozpoczecia >= DataRozpoczecia && promocje.DataZakonczenia <= DataZakonczenia
                select "Suma rabatu:" + " " + promocje.Rabat + " " + "Nazwa promocji:" + " " + promocje.Nazwa
                ).ToList();
        }
        #endregion
    }
}
