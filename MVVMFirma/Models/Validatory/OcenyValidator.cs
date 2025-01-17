using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.Validatory
{
    public class OcenyValidator
    {
        public static string SprawdzOcene(decimal? ocena)
        {
            if (ocena < 0 || ocena > 10)
                return "Ocena musi być w przedziale od 0-10!";
            return null;
        }
    }
}
