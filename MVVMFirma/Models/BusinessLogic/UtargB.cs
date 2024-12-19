using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class UtargB : DatabaseClass
    {
        #region Konstruktor
        public UtargB(KinoEntities db)
            : base(db) { }
        #endregion
        #region Funkcje biznesowe
        //Funckja oblicza  całkowitą kwotę sprzedaży za Dany tytuł filmu! <---!
        public double? UtargOkresTowar(int FilmID)
        {
            return (
                from bilet in db.Bilet
                where bilet.FilmID == FilmID
                select bilet
            ).Sum(x => (double?)x.Cena);
        }
        #endregion
    }
}
