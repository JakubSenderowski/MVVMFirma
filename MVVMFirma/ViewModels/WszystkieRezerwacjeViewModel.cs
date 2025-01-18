using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class WszystkieRezerwacjeViewModel:WszystkieViewModel<RezerwacjaForAllView>
    {
        #region Constructor
        public WszystkieRezerwacjeViewModel()
            : base("Rezerwacje")
        {
        }
        #endregion
        #region Sort And Find
        //Tutaj decydujemy po czym sortować do ComboBoxa <---
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "LiczbaBiletow" };
        }
        //Tutaj decydujemy jak sortować <---
        public override void Sort()
        {
            if (SortField == "LiczbaBiletow")
            {
                List = new ObservableCollection<RezerwacjaForAllView>
                    (List.OrderBy(item => item.LiczbaBiletow));
            }
        }
        //Tutaj decydujemy po czym szukać do ComboBoxa<---
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "StatusRezerwacji", "KlientImie", "KlientNazwisko" };
        }
        //Tutaj decydujemy jak wyszukiwać <---
        public override void Find()
        {
            if (FindField == "StatusRezerwacji")
            {
                List = new ObservableCollection<RezerwacjaForAllView>
                    (List.Where(item => item.StatusRezerwacji != null && item.StatusRezerwacji.StartsWith(FindTextBox)));
            }
            if (FindField == "KlientImie")
            {
                List = new ObservableCollection<RezerwacjaForAllView>
                    (List.Where(item => item.KlientImie != null && item.KlientImie.StartsWith(FindTextBox)));
            }
            if (FindField == "KlientNazwisko")
            {
                List = new ObservableCollection<RezerwacjaForAllView>
                    (List.Where(item => item.KlientNazwisko != null && item.KlientNazwisko.StartsWith(FindTextBox)));
            }
        }
        #endregion
        #region Helpers
        //Metoda Load pobiera wszystkie towary z bazy danych.
        public override void Load()
        {
            List = new ObservableCollection<RezerwacjaForAllView>
                (
                    from Rezerwacja in kinoEntities.Rezerwacja //Dla każdej faktury z bazy danych faktur
                    select new RezerwacjaForAllView //Tworzymy nową FakturęForAllView i uzupełniamy jej dane
                    {
                        RezerwacjaID = Rezerwacja.RezerwacjaID,
                        KlientImie = Rezerwacja.Klient.Imie,
                        KlientNazwisko = Rezerwacja.Klient.Nazwisko,
                        KlientMail = Rezerwacja.Klient.Email,
                        KlientNumer = Rezerwacja.Klient.Telefon,
                        DataRezerwacji = Rezerwacja.DataRezerwacji,
                        DataSeansu = Rezerwacja.DataSeansu,
                        LiczbaBiletow = Rezerwacja.LiczbaBiletów,
                        StatusRezerwacji = Rezerwacja.StatusRezerwacji,
                    }
                );
        }
        #endregion
    }
}
