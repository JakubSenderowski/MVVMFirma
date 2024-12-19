using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    internal class RankingFilmyB : DatabaseClass
    {
        #region Konstruktor
        public RankingFilmyB(KinoEntities db)
            : base(db) { }
        #endregion
        #region Funkcje biznesowe
        //Funckja oblicza  całkowitą kwotę sprzedaży za Dany tytuł filmu! <---!
        public List<String> RankingFilmOkres(int FilmID, int minOcena, int maxOcena)
        {   
            
            return
            (
                from Recenzja in db.Recenzja
                where Recenzja.FilmID == FilmID && Recenzja.Ocena >= minOcena && Recenzja.Ocena <= maxOcena
                select  Recenzja.Film.Tytul

            ).ToList();
        }
        #endregion
    }
}
