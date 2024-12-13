using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class SposobyPlatnosciB : DatabaseClass
    {
        #region Kontruktor
        public SposobyPlatnosciB(KinoEntities db)
            : base(db) { }
        #endregion
        #region Funkcje Biznesowe
        //Funkcja, która zwraca ID towarów, nazwy i kod w KeyAndValue
        public IQueryable<KeyAndValue> GetSposobyPlatnosciKeyAndValueItems()
        {
            return (
                from sposob in db.SposobPlatnosci
                select new KeyAndValue
                {
                    Key = sposob.IdSposobuPlatnosci,
                    Value = sposob.Nazwa
                }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}
