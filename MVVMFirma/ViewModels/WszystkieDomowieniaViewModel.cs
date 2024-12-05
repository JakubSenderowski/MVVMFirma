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
    public class WszystkieDomowieniaViewModel: WszystkieViewModel<DomowieniaForAllView>
    {
        #region Constructor
        public WszystkieDomowieniaViewModel()
            : base("Domowienia")
        {
        }
        #endregion
        #region Helpers
        //Metoda Load pobiera wszystkie towary z bazy danych.
        public override void Load()
        {
            List = new ObservableCollection<DomowieniaForAllView>
                (
                    from Domowienia in kinoEntities.Domowienia //Dla każdej faktury z bazy danych faktur
                    select new DomowieniaForAllView //Tworzymy nową FakturęForAllView i uzupełniamy jej dane
                    {
                        IdDomowienia = Domowienia.IdDomowienia,
                        TypBiletu = Domowienia.Bilet.TypBiletu,
                        NazwaTowaru = Domowienia.Towar.Nazwa,
                        Ilosc = Domowienia.Ilosc,
                        Cena = Domowienia.Cena,
                    }
                );
        }
        #endregion
    }
}
