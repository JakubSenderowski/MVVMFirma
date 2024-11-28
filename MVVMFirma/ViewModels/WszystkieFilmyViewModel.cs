using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class WszystkieFilmyViewModel : WszystkieViewModel<Film>
    {
        public WszystkieFilmyViewModel()
            : base("Filmy")
        { 
        }
        public override void Load()
        {
            List = new ObservableCollection<Film>
                (kinoEntities.Film.ToList()); //Z bazy danych pobiera Towar i wszystkie rekordy zamienia na listę.
        }
    }
}
