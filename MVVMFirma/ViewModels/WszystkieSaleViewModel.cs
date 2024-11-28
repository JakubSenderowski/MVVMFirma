using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class WszystkieSaleViewModel: WszystkieViewModel<Sala>
    {
        public WszystkieSaleViewModel()
            : base("Sale")
        { 
        }
        public override void Load()
        {
            List = new ObservableCollection<Sala>
                (kinoEntities.Sala.ToList()); //Z bazy danych pobiera Towar i wszystkie rekordy zamienia na listę.
        }
    }
}
