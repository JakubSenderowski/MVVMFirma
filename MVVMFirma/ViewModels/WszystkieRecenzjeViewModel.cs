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
    public class WszystkieRecenzjeViewModel:WszystkieViewModel<RecenzjaForAllView>
    {
        #region Constructor
        public WszystkieRecenzjeViewModel()
            : base("Recenzje")
        {
        }
        #endregion
        #region Sort And Find
        //Tutaj decydujemy po czym sortować do ComboBoxa <---
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Ocena" };
        }
        //Tutaj decydujemy jak sortować <---
        public override void Sort()
        {
            if (SortField == "Ocena")
            {
                List = new ObservableCollection<RecenzjaForAllView>
                    (List.OrderBy(item => item.Ocena));
            }
        }
        //Tutaj decydujemy po czym szukać do ComboBoxa<---
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Autor", "FilmTytul" };
        }
        //Tutaj decydujemy jak wyszukiwać <---
        public override void Find()
        {
            if (FindField == "Autor")
            {
                List = new ObservableCollection<RecenzjaForAllView>
                    (List.Where(item => item.Autor != null && item.Autor.StartsWith(FindTextBox)));
            }
            if (FindField == "FilmTytul")
            {
                List = new ObservableCollection<RecenzjaForAllView>
                    (List.Where(item => item.FilmTytul != null && item.FilmTytul.StartsWith(FindTextBox)));
            }
        }
        #endregion
        #region Helpers
        //Metoda Load pobiera wszystkie towary z bazy danych.
        public override void Load()
        {
            List = new ObservableCollection<RecenzjaForAllView>
                (
                    from Recenzja in kinoEntities.Recenzja //Dla każdej faktury z bazy danych faktur
                    select new RecenzjaForAllView //Tworzymy nową FakturęForAllView i uzupełniamy jej dane
                    {
                        RecenzjaID = Recenzja.RecenzjaID,
                        Autor = Recenzja.Autor,
                        Ocena = Recenzja.Ocena,
                        Komentarz = Recenzja.Komentarz,
                        FilmTytul = Recenzja.Film.Tytul,
                        FilmOpis = Recenzja.Film.Opis,
                    }
                );
        }
        #endregion
    }
}
