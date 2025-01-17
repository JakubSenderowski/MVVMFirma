using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.Validatory
{
    public class RabatValidator
    {
        public static string SprawdzRabat(decimal? rabat)
        {
            if (rabat < 0 || rabat >50)
                return "Rabat musi mieścić się w przedziale 0-50!";
            return null;
        }
    }
}
