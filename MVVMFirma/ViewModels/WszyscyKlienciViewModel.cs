using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class WszyscyKlienciViewModel : WszystkieViewModel<Klient>
    {
        public WszyscyKlienciViewModel()
            : base("Klienci")
        { 
        }
        public override void Load()
        {
            List = new ObservableCollection<Klient>
                (kinoEntities.Klient.ToList()); //Z bazy danych pobiera Towar i wszystkie rekordy zamienia na listę.
        }
    }
}
