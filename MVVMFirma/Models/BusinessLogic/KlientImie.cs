using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class KlientImie : DatabaseClass
    {
        #region Kontruktor
        public KlientImie(KinoEntities db)
            : base(db) { }
        #endregion
        #region Funkcje Biznesowe
        //Funkcja, która zwraca ID towarów, nazwy i kod w KeyAndValue
        public IQueryable<KeyAndValue> GetKlientImieKeyAndValueItems()
        {
            return (
                from klienci in db.Klient
                select new KeyAndValue
                {
                    Key = klienci.KlientID,
                    Value = klienci.Imie
                }
                ).ToList().AsQueryable();
            #endregion
        }
    }
}
