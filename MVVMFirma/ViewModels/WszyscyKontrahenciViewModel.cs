using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class WszyscyKontrahenciViewModel:WszystkieViewModel<Kontrahent>
    {
        public WszyscyKontrahenciViewModel()
            : base("Kontrahenci")
        { 
        }
        public override void Load()
        {
            List = new ObservableCollection<Kontrahent>
                (kinoEntities.Kontrahent.ToList()); //Z bazy danych pobiera Towar i wszystkie rekordy zamienia na listę.
        }
    }
}
