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
