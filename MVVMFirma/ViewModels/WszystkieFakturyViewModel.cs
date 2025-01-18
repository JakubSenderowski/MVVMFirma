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
        #region Sort And Find
        //Tutaj decydujemy po czym sortować do ComboBoxa <---
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Numer", "KontrahentNIP" };
        }
        //Tutaj decydujemy jak sortować <---
        public override void Sort()
        {
            if (SortField == "Numer")
            {
                List = new ObservableCollection<FakturaForAllView>
                    (List.OrderBy(item => item.Numer));
            }
            if (SortField == "KontrahentNIP")
            {
                List = new ObservableCollection<FakturaForAllView>
                    (List.OrderBy(item => item.KontrahentNIP));
            }
        }
        //Tutaj decydujemy po czym szukać do ComboBoxa<---
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "SposobPlatnosciNazwa" };
        }
        //Tutaj decydujemy jak wyszukiwać <---
        public override void Find()
        {
            if (FindField == "SposobPlatnosciNazwa")
            {
                List = new ObservableCollection<FakturaForAllView>
                    (List.Where(item => item.SposobPlatnosciNazwa != null && item.SposobPlatnosciNazwa.StartsWith(FindTextBox)));
            }
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
