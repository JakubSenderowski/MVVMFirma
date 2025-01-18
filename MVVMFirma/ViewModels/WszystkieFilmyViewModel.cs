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
        #region Sort And Find
        //Tutaj decydujemy po czym sortować do ComboBoxa <---
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "CzasTrwania" };
        }
        //Tutaj decydujemy jak sortować <---
        public override void Sort()
        {
            if (SortField == "CzasTrwania")
            {
                List = new ObservableCollection<Film>
                    (List.OrderBy(item => item.CzasTrwania));
            }
        }
        //Tutaj decydujemy po czym szukać do ComboBoxa<---
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Tytul" };
        }
        //Tutaj decydujemy jak wyszukiwać <---
        public override void Find()
        {
            if (FindField == "Tytul")
            {
                List = new ObservableCollection<Film>
                    (List.Where(item => item.Tytul != null && item.Tytul.StartsWith(FindTextBox)));
            }
        }
        #endregion
        public override void Load()
        {
            List = new ObservableCollection<Film>
                (kinoEntities.Film.ToList()); //Z bazy danych pobiera Towar i wszystkie rekordy zamienia na listę.
        }
    }
}
