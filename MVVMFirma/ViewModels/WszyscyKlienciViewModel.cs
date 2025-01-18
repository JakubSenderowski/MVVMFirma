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
        #region Sort And Find
        //Tutaj decydujemy po czym sortować do ComboBoxa <---
        public override List<string> GetComboboxSortList()
        {
            return new List<string> {"Nazwisko" };
        }
        //Tutaj decydujemy jak sortować <---
        public override void Sort()
        {
            if (SortField == "Nazwisko")
            {
                List = new ObservableCollection<Klient>
                    (List.OrderBy(item => item.Nazwisko));
            }
        }
        //Tutaj decydujemy po czym szukać do ComboBoxa<---
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Email", "Telefon" };
        }
        //Tutaj decydujemy jak wyszukiwać <---
        public override void Find()
        {
            if (FindField == "Email")
            {
                List = new ObservableCollection<Klient>
                    (List.Where(item => item.Email != null && item.Email.StartsWith(FindTextBox)));
            }
            if (FindField == "Telefon")
            {
                List = new ObservableCollection<Klient>
                    (List.Where(item => item.Telefon != null && item.Telefon.StartsWith(FindTextBox)));
            }
        }
        #endregion
        public override void Load()
        {
            List = new ObservableCollection<Klient>
                (kinoEntities.Klient.ToList()); //Z bazy danych pobiera Towar i wszystkie rekordy zamienia na listę.
        }
    }
}
