using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class SalaB:DatabaseClass
    {
        #region Kontruktor
        public SalaB(KinoEntities db)
            : base(db) { }
        #endregion
        #region Funkcje Biznesowe
        //Funkcja, która zwraca ID towarów, nazwy i kod w KeyAndValue
        public IQueryable<KeyAndValue> GetSalaKeyAndValueItems()
        {
            return (
                from sala in db.Sala
                select new KeyAndValue
                {
                    Key = sala.SalaID,
                    Value = sala.NumerSali.ToString()
                }
                ).ToList().AsQueryable();
            #endregion
        }
    }
}
