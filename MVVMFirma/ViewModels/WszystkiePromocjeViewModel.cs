using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace MVVMFirma.ViewModels
{
    public class WszystkiePromocjeViewModel:WszystkieViewModel<PromocjaForAllView>
    {
        #region Constructor
        public WszystkiePromocjeViewModel()
            : base("Promocje")
        {
        }
        #endregion
        #region Sort And Find
        //Tutaj decydujemy po czym sortować do ComboBoxa <---
        public override List<string> GetComboboxSortList()
        {
            return new List<string> {"Rabat" };
        }
        //Tutaj decydujemy jak sortować <---
        public override void Sort()
        {
            if (SortField == "Rabat")
            {
                List = new ObservableCollection<PromocjaForAllView>
                    (List.OrderBy(item => item.Rabat));
            }
        }
        //Tutaj decydujemy po czym szukać do ComboBoxa<---
        public override List<string> GetComboboxFindList()
        {
            return new List<string> {"TypBiletu" };
        }
        //Tutaj decydujemy jak wyszukiwać <---
        public override void Find()
        {
            if (FindField == "TypBiletu")
            {
                List = new ObservableCollection<PromocjaForAllView>
                    (List.Where(item => item.TypBiletu != null && item.TypBiletu.StartsWith(FindTextBox)));
            }
        }
        #endregion
        #region Helpers
        //Metoda Load pobiera wszystkie towary z bazy danych.
        public override void Load()
        {
            List = new ObservableCollection<PromocjaForAllView>
                (
                    from promocja in kinoEntities.Promocja //Dla każdej faktury z bazy danych faktur
                    select new PromocjaForAllView //Tworzymy nową FakturęForAllView i uzupełniamy jej dane
                    {
                        PromocjaID = promocja.PromocjaID,
                        Opis = promocja.Opis,
                        TypBiletu = promocja.Bilet.TypBiletu,
                        Rabat = promocja.Rabat,
                        DataRozpoczecia = promocja.DataRozpoczecia,
                        DataZakonczenia = promocja.DataZakonczenia,
                        Tytul = promocja.Film.Tytul,
                    }
                );
        }
        #endregion
    }
}
