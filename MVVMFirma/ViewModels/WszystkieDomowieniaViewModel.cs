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
        #region Sort And Find
        //Tutaj decydujemy po czym sortować do ComboBoxa <---
        public override List<string> GetComboboxSortList()
        {
            return new List<string> {  "Ilosc", "Cena" };
        }
        //Tutaj decydujemy jak sortować <---
        public override void Sort()
        {
            if (SortField == "Ilosc")
            {
                List = new ObservableCollection<DomowieniaForAllView>
                    (List.OrderBy(item => item.Ilosc));
            }
            if (SortField == "Cena")
            {
                List = new ObservableCollection<DomowieniaForAllView>
                    (List.OrderBy(item => item.Cena));
            }
        }
        //Tutaj decydujemy po czym szukać do ComboBoxa<---
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "TypBiletu", "NazwaTowaru" };
        }
        //Tutaj decydujemy jak wyszukiwać <---
        public override void Find()
        {
            if (FindField == "TypBiletu")
            {
                List = new ObservableCollection<DomowieniaForAllView>
                    (List.Where(item => item.TypBiletu != null && item.TypBiletu.StartsWith(FindTextBox)));
            }
            if (FindField == "NazwaTowaru")
            {
                List = new ObservableCollection<DomowieniaForAllView>
                    (List.Where(item => item.NazwaTowaru != null && item.NazwaTowaru.StartsWith(FindTextBox)));
            }
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
