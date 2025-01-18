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
        #region Sort And Find
        //Tutaj decydujemy po czym sortować do ComboBoxa <---
        public override List<string> GetComboboxSortList()
        {
            return new List<string> {"Opis" };
        }
        //Tutaj decydujemy jak sortować <---
        public override void Sort()
        {
            if (SortField == "Opis")
            {
                List = new ObservableCollection<Sala>
                    (List.OrderBy(item => item.Opis));
            }
        }
        //Tutaj decydujemy po czym szukać do ComboBoxa<---
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "NumerSali", "LiczbaMiejsc" };
        }
        //Tutaj decydujemy jak wyszukiwać <---
        public override void Find()
        {
            if (FindField == "NumerSali")
            {
                List = new ObservableCollection<Sala>
                    (List.Where(item => item.NumerSali.ToString().StartsWith(FindTextBox)));
            }
            if (FindField == "LiczbaMiejsc")
            {
                List = new ObservableCollection<Sala>
                    (List.Where(item => item.LiczbaMiejsc.ToString().StartsWith(FindTextBox)));
            }
        }
        #endregion
        public override void Load()
        {
            List = new ObservableCollection<Sala>
                (kinoEntities.Sala.ToList()); //Z bazy danych pobiera Towar i wszystkie rekordy zamienia na listę.
        }
    }
}
