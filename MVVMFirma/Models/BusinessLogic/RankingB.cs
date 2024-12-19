using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    internal class RankingB:DatabaseClass
    {
        public RankingB(KinoEntities db)
            : base(db) { }
        public int? LiczbaSprzedanychBiletowDlaFilmu(int FilmID)
        {
            return (
                from bilet in db.Bilet
                where bilet.FilmID == FilmID
                select bilet
            ).Count();
        }
    }
}
