using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class BiletCenaB : DatabaseClass
    {
        #region Kontruktor
        public BiletCenaB(KinoEntities db)
            : base(db) { }
        #endregion
        #region Funkcje Biznesowe
        //Funkcja, która zwraca ID towarów, nazwy i kod w KeyAndValue
        public IQueryable<KeyAndValue> GetBiletCenaKeyAndValueItems()
        {
            return (
                from biletcena in db.Bilet
                select new KeyAndValue
                {
                    Key = biletcena.BiletID,
                    Value = biletcena.Cena.ToString(),
                }
                ).ToList().AsQueryable();
            #endregion
        }
    }
}
