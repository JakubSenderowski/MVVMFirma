using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using MVVMFirma.Models.Entities;
using MVVMFirma.Helper;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{   //Jest to klasa, która odostarcza danych do widoku wyświetaljącego wszystkie towary.
    public class WszystkieTowaryViewModel : WszystkieViewModel<Towar>
    {
        
        #region Constructor
        public WszystkieTowaryViewModel()
            :base("Towary")
        {
        }
        #endregion
        #region Sort And Find
        //Tutaj decydujemy po czym sortować do ComboBoxa <---
        public override List<string> GetComboboxSortList()
        {
            return new List<string> {"Kod", "Nazwa", "Cena"};
        }
        //Tutaj decydujemy jak sortować <---
        public override void Sort()
        {
            if (SortField == "Kod")
            {
                List = new ObservableCollection<Towar>
                    (List.OrderBy(item => item.Kod));
            }
            if (SortField == "Nazwa")
            {
                List = new ObservableCollection<Towar>
                    (List.OrderBy(item => item.Nazwa));
            }
            if (SortField == "Cena")
            {
                List = new ObservableCollection<Towar>
                    (List.OrderBy(item => item.Cena));
            }
        }
        //Tutaj decydujemy po czym szukać do ComboBoxa<---
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Kod", "Nazwa" };
        }
        //Tutaj decydujemy jak wyszukiwać <---
        public override void Find()
        {
            if (FindField == "Kod")
            {
                List = new ObservableCollection<Towar>
                    (List.Where(item => item.Kod != null && item.Kod.StartsWith(FindTextBox)));
            }
            if (FindField == "Nazwa")
            {
                List = new ObservableCollection<Towar>
                    (List.Where(item => item.Nazwa != null && item.Nazwa.StartsWith(FindTextBox)));
            }
        }
        #endregion
        #region Helpers
        //Metoda Load pobiera wszystkie towary z bazy danych.
        public override void Load()
        {
            List=new ObservableCollection<Towar>
                (kinoEntities.Towar.ToList()); //Z bazy danych pobiera Towar i wszystkie rekordy zamienia na listę.
        }
        #endregion
        
    }
}