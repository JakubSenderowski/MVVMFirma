using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.Validatory
{
    public class StringValidator

    {
        public static string SprawdzCzyZaczynaSieOdDuzej(string wartosc)
        {
            try
            {
                if(!char.IsUpper(wartosc, 0))
                    return "Wartość musi zaczynać się od dużej litery";
            }
            catch (Exception e) { }
            return null;
        }
    }
}
