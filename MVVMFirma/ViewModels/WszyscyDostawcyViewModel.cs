using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class WszyscyDostawcyViewModel: WszystkieViewModel<Dostawca>
    {
        public WszyscyDostawcyViewModel()
            : base("Dostawcy") 
        {
        }
        public override void Load()
        {
            List = new ObservableCollection<Dostawca>
                (kinoEntities.Dostawca.ToList()); //Z bazy danych pobiera Towar i wszystkie rekordy zamienia na listę.
        }
    }
}
