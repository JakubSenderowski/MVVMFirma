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
    public class WszystkieFakturyViewModel:WszystkieViewModel<FakturaForAllView>
    {
        #region Constructor
        public WszystkieFakturyViewModel()
            : base("Faktury")
        {
        }
        #endregion
        #region Helpers
        //Metoda Load pobiera wszystkie towary z bazy danych.
        public override void Load()
        {
            List = new ObservableCollection<FakturaForAllView>
                (
                    from faktura in kinoEntities.Faktura //Dla każdej faktury z bazy danych faktur
                    select new FakturaForAllView //Tworzymy nową FakturęForAllView i uzupełniamy jej dane
                    { 
                        IdFaktury = faktura.IdFaktury, 
                        Numer = faktura.Numer,
                        CzyZatwierdzona = faktura.CzyZatwierdzona,
                        DataWystawienia = faktura.DataWystawienia,
                        KontrahentNIP = faktura.Kontrahent.NIP,
                        KontrahentNazwa = faktura.Kontrahent.Nazwa,
                        TerminPlatnosci = faktura.TerminPlatnosci,
                        SposobPlatnosciNazwa = faktura.SposobPlatnosci.Nazwa,
                        DostawcaID = faktura.Dostawca.DostawcaID,
                    }
                );
        }
        #endregion
    }
}
