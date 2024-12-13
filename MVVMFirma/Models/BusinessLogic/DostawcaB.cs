using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class DostawcaB:DatabaseClass
    {
        #region Kontruktor
        public DostawcaB(KinoEntities db)
            : base(db) { }
        #endregion
        #region Funkcje Biznesowe
        //Funkcja, która zwraca ID towarów, nazwy i kod w KeyAndValue
        public IQueryable<KeyAndValue> GetDostawcyKeyAndValueItems()
        {
            return (
                from dostawca in db.Dostawca
                select new KeyAndValue
                {
                    Key = dostawca.DostawcaID,
                    Value = dostawca.Nazwa
                }
                ).ToList().AsQueryable();
            #endregion
        }
    }
}
