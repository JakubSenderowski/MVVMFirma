using MVVMFirma.Models.BusinessLogic;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models
{
    public class BiletB : DatabaseClass
    {
        #region Kontruktor
        public BiletB(KinoEntities db)
            : base(db) { }
        #endregion
        #region Funkcje Biznesowe
        //Funkcja, która zwraca ID towarów, nazwy i kod w KeyAndValue
        public IQueryable<KeyAndValue> GetBiletKeyAndValueItems()
        {
            return (
                from bilety in db.Bilet
                select new KeyAndValue
                {
                    Key = bilety.BiletID,
                    Value = bilety.TypBiletu
                }
                ).ToList().AsQueryable();
            #endregion
        }
    }
}