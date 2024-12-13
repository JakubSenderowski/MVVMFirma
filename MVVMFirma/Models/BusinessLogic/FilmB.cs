using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class FilmB:DatabaseClass
    {
        #region Kontruktor
        public FilmB(KinoEntities db)
            : base(db) { }
        #endregion
        #region Funkcje Biznesowe
        //Funkcja, która zwraca ID towarów, nazwy i kod w KeyAndValue
        public IQueryable<KeyAndValue> GetFilmKeyAndValueItems()
        {
            return (
                from filmy in db.Film
                select new KeyAndValue
                {
                    Key = filmy.FilmID,
                    Value = filmy.Tytul
                }
                ).ToList().AsQueryable();
            #endregion
        }
    }
}
