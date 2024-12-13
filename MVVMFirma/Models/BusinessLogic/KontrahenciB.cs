using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class KontrahenciB:DatabaseClass
    {
        #region Kontruktor
        public KontrahenciB(KinoEntities db)
            : base(db) { }
        #endregion
        #region Funkcje Biznesowe
        //Funkcja, która zwraca ID towarów, nazwy i kod w KeyAndValue
        public IQueryable<KeyAndValue> GetKontrahenciKeyAndValueItems()
        {
            return (
                from kontrahent in db.Kontrahent
                select new KeyAndValue
                {
                    Key = kontrahent.IdKontrahenta,
                    Value = kontrahent.Nazwa + " " + kontrahent.NIP
                }
                ).ToList().AsQueryable();
            #endregion
        }
    }
}
