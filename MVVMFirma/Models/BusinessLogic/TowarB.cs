using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class TowarB : DatabaseClass
    {
        #region Kontruktor
        public TowarB(KinoEntities db)
            : base(db) { }
        #endregion
        #region Funkcje Biznesowe
        //Funkcja, która zwraca ID towarów, nazwy i kod w KeyAndValue
        public IQueryable<KeyAndValue> GetTowaryKeyAndValueItems()
        {
            return (
                from towar in db.Towar
                select new KeyAndValue
                {
                    Key = towar.IdTowaru,
                    Value = towar.Nazwa + " " + towar.Kod
                }
                ).ToList().AsQueryable();
            #endregion
        }
    }
}
