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
    public class WszystkieRepertuaryViewModel:WszystkieViewModel<RepertuarForAllView>
    {
        #region Constructor
        public WszystkieRepertuaryViewModel()
            : base("Repertuary")
        {
        }
        #endregion
        #region Sort And Find
        //Tutaj decydujemy po czym sortować do ComboBoxa <---
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "GodzinySeansow"};
        }
        //Tutaj decydujemy jak sortować <---
        public override void Sort()
        {
            if (SortField == "GodzinySeansow")
            {
                List = new ObservableCollection<RepertuarForAllView>
                    (List.OrderBy(item => item.GodzinySeansow));
            }
        }
        //Tutaj decydujemy po czym szukać do ComboBoxa<---
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "TytulFilmu", "NumerSali" };
        }
        //Tutaj decydujemy jak wyszukiwać <---
        public override void Find()
        {
            if (FindField == "TytulFilmu")
            {
                List = new ObservableCollection<RepertuarForAllView>
                    (List.Where(item => item.TytulFilmu != null && item.TytulFilmu.StartsWith(FindTextBox)));
            }
            if (FindField == "NumerSali")
            {
                List = new ObservableCollection<RepertuarForAllView>
                    (List.Where(item => item.NumerSali.ToString().StartsWith(FindTextBox)));
            }
        }
        #endregion
        #region Helpers
        //Metoda Load pobiera wszystkie towary z bazy danych.
        public override void Load()
        {
            List = new ObservableCollection<RepertuarForAllView>
                (
                    from Repertuar in kinoEntities.Repertuar //Dla każdej faktury z bazy danych faktur
                    select new RepertuarForAllView //Tworzymy nową FakturęForAllView i uzupełniamy jej dane
                    {
                        RepertuarID = Repertuar.RepertuarID,
                        Data = Repertuar.Data,
                        GodzinySeansow = Repertuar.GodzinySeansow,
                        NumerSali = Repertuar.Sala.NumerSali,
                        TytulFilmu = Repertuar.Film.Tytul,
                    }
                );
        }
        #endregion
    }
}
