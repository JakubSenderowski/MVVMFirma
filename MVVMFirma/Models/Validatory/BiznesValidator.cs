using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.Validatory
{
    public class BiznesValidator
    {
        public static string SprawdzVat(decimal? vat)
        { 
            if(vat < 0 || vat > 100)
                return "Vat musi znajdować się w przedziale 0-100!";
            return null;
        }
    }
}
