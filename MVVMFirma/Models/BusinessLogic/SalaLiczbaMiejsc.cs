using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    internal class SalaLiczbaMiejsc:DatabaseClass
    {
        #region Kontruktor
        public SalaLiczbaMiejsc(KinoEntities db)
            : base(db) { }
        #endregion
        #region Funkcje Biznesowe
        //Funkcja, która zwraca ID towarów, nazwy i kod w KeyAndValue
        public IQueryable<KeyAndValue> GetSalaLiczbaMiejscKeyAndValueItems()
        {
            return (
                from sala in db.Sala
                select new KeyAndValue
                {
                    Key = sala.SalaID,
                    Value = sala.LiczbaMiejsc.ToString()
                }
                ).ToList().AsQueryable();
            #endregion
        }
    }
}
