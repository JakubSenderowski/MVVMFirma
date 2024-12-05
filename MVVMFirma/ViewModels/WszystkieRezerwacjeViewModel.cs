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
