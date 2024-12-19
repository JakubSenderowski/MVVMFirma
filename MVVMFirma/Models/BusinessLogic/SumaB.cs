using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class SumaB : DatabaseClass
    {
        public SumaB(KinoEntities db)
            : base(db) { }
        public decimal? SumaCaloscTowar(int TowarID)
        {
            return (
                 from domowienia in db.Domowienia
                 where domowienia.TowarID == TowarID
                 select domowienia.Ilosc * domowienia.Cena
             ).Sum();
        }
    }
}
