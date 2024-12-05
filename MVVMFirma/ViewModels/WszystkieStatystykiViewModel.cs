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
