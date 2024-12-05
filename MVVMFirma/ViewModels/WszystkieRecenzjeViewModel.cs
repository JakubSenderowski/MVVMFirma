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
