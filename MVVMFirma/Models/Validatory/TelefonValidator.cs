using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.Validatory
{
    public class TelefonValidator
    {
        public static string SprawdzTelefon(string telefon) 
        
        {
            if (string.IsNullOrEmpty(telefon))
            {
                return "Telefon nie może być pusty.";
            }

            if (telefon.Length != 9)
                return "Numer telefonu musi mieć dokładnie 9 cyfr - zweryfikuj poprawność!";
            return null;
        }
    }
}
