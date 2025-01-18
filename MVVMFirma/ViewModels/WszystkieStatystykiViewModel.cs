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
    public class WszystkieStatystykiViewModel:WszystkieViewModel<StatystykaForAllView>
    {
        #region Constructor
        public WszystkieStatystykiViewModel()
            : base("Statystki")
        {
        }
        #endregion
        #region Sort And Find
        //Tutaj decydujemy po czym sortować do ComboBoxa <---
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "LacznyPrzychod" };
        }
        //Tutaj decydujemy jak sortować <---
        public override void Sort()
        {
            if (SortField == "LacznyPrzychod")
            {
                List = new ObservableCollection<StatystykaForAllView>
                    (List.OrderBy(item => item.LacznyPrzychod));
            }
        }
        //Tutaj decydujemy po czym szukać do ComboBoxa<---
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "FilmTytul", "LiczbaSprzedanychBiletow" };
        }
        //Tutaj decydujemy jak wyszukiwać <---
        public override void Find()
        {
            if (FindField == "FilmTytul")
            {
                List = new ObservableCollection<StatystykaForAllView>
                    (List.Where(item => item.FilmTytul != null && item.FilmTytul.StartsWith(FindTextBox)));
            }
            if (FindField == "LiczbaSprzedanychBiletow")
            {
                List = new ObservableCollection<StatystykaForAllView>
                    (List.Where(item => item.LiczbaSprzedanychBiletow.ToString().StartsWith(FindTextBox)));
            }
        }
        #endregion
        #region Helpers
        //Metoda Load pobiera wszystkie towary z bazy danych.
        public override void Load()
        {
            List = new ObservableCollection<StatystykaForAllView>
                (
                    from Statystyki in kinoEntities.Statystyki //Dla każdej faktury z bazy danych faktur
                    select new StatystykaForAllView //Tworzymy nową FakturęForAllView i uzupełniamy jej dane
                    {
                        StatystykiID = Statystyki.StatystykiID,
                        Data = Statystyki.Data,
                        LiczbaSprzedanychBiletow = Statystyki.LiczbaSprzedanychBiletow,
                        LacznyPrzychod = Statystyki.LacznyPrzychod,
                        FilmTytul = Statystyki.Film.Tytul,
                        SalaLiczbaMiejsc = Statystyki.Sala.LiczbaMiejsc,
                    }
                );
        }
        #endregion
    }
}
