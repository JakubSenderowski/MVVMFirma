using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class DatabaseClass
    {
        #region DB
        public KinoEntities db { get; set; }
        #endregion
        #region Kontruktor
        public DatabaseClass(KinoEntities db) { 
            this.db = db;
        }
        #endregion
    }
}
