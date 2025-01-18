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
        #region Sort And Find
        //Tutaj decydujemy po czym sortować do ComboBoxa <---
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Nazwa" };
        }
        //Tutaj decydujemy jak sortować <---
        public override void Sort()
        {
            if (SortField == "Nazwa")
            {
                List = new ObservableCollection<Dostawca>
                    (List.OrderBy(item => item.Nazwa));
            }
        }
        //Tutaj decydujemy po czym szukać do ComboBoxa<---
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Email" };
        }
        //Tutaj decydujemy jak wyszukiwać <---
        public override void Find()
        {
            if (FindField == "Email")
            {
                List = new ObservableCollection<Dostawca>
                    (List.Where(item => item.Email != null && item.Email.StartsWith(FindTextBox)));
            }
        }
        #endregion
        public override void Load()
        {
            List = new ObservableCollection<Dostawca>
                (kinoEntities.Dostawca.ToList()); //Z bazy danych pobiera Towar i wszystkie rekordy zamienia na listę.
        }
    }
}
