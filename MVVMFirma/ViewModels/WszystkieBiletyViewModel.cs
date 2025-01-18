using GalaSoft.MvvmLight.Messaging;
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
    public class WszystkieBiletyViewModel:WszystkieViewModel<BiletForAllView>
    {
        #region Constructor
        public WszystkieBiletyViewModel()
            : base("Bilety")
        {
        }
        #endregion
        #region Sort And Find
        //Tutaj decydujemy po czym sortować do ComboBoxa <---
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Cena" };
        }
        //Tutaj decydujemy jak sortować <---
        public override void Sort()
        {
            if (SortField == "Cena")
            {
                List = new ObservableCollection<BiletForAllView>
                    (List.OrderBy(item => item.Cena));
            }
        }
        //Tutaj decydujemy po czym szukać do ComboBoxa<---
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "TypBiletu", "FilmTytul" };
        }
        //Tutaj decydujemy jak wyszukiwać <---
        public override void Find()
        {
            if (FindField == "TypBiletu")
            {
                List = new ObservableCollection<BiletForAllView>
                    (List.Where(item => item.TypBiletu != null && item.TypBiletu.StartsWith(FindTextBox)));
            }
            if (FindField == "FilmTytul")
            {
                List = new ObservableCollection<BiletForAllView>
                    (List.Where(item => item.FilmTytul != null && item.FilmTytul.StartsWith(FindTextBox)));
            }
        }
        #endregion
        #region Properties

        private BiletForAllView _WybranyBiletForAllView;
        public BiletForAllView WybranyBiletForAllView
        {
            get
            {
                return _WybranyBiletForAllView;
            }
            set
            {
                _WybranyBiletForAllView = value;
                if (value != null)
                {
                    // Tworzymy nowy obiekt Bilet z danymi z widoku
                    var bilet = new Bilet()
                    {
                        BiletID = value.BiletID,
                        TypBiletu = value.TypBiletu
                        // możesz dodać inne potrzebne właściwości
                    };
                    Messenger.Default.Send(bilet);
                    OnRequestClose();
                }
            }
        }
        #endregion
        #region Helpers
        //Metoda Load pobiera wszystkie towary z bazy danych.
        public override void Load()
        {
            List = new ObservableCollection<BiletForAllView>
                (
                    from bilet in kinoEntities.Bilet //Dla każdej faktury z bazy danych faktur
                    select new BiletForAllView //Tworzymy nową FakturęForAllView i uzupełniamy jej dane
                    {
                        BiletID = bilet.BiletID,
                        Cena = bilet.Cena,
                        TypBiletu = bilet.TypBiletu,
                        Opis = bilet.Opis,
                        FilmTytul = bilet.Film.Tytul,
                    }
                );
        }
        #endregion
    }
}
