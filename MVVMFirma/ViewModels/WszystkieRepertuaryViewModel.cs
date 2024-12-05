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
