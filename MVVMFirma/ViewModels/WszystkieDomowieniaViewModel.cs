using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class WszystkieDomowieniaViewModel: WszystkieViewModel<Domowienia>
    {
        public WszystkieDomowieniaViewModel()
            : base("Domowienia")
        { 
        }
        public override void Load()
        {
            List = new ObservableCollection<Domowienia>
                (kinoEntities.Domowienia.ToList()); //Z bazy danych pobiera Towar i wszystkie rekordy zamienia na listę.
        }
    }
}
