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
    public class WszystkiePromocjeViewModel:WszystkieViewModel<PromocjaForAllView>
    {
        #region Constructor
        public WszystkiePromocjeViewModel()
            : base("Promocje")
        {
        }
        #endregion
        #region Helpers
        //Metoda Load pobiera wszystkie towary z bazy danych.
        public override void Load()
        {
            List = new ObservableCollection<PromocjaForAllView>
                (
                    from promocja in kinoEntities.Promocja //Dla każdej faktury z bazy danych faktur
                    select new PromocjaForAllView //Tworzymy nową FakturęForAllView i uzupełniamy jej dane
                    {
                        PromocjaID = promocja.PromocjaID,
                        Opis = promocja.Opis,
                        TypBiletu = promocja.Bilet.TypBiletu,
                        Rabat = promocja.Rabat,
                        DataRozpoczecia = promocja.DataRozpoczecia,
                        DataZakonczenia = promocja.DataZakonczenia,
                        Tytul = promocja.Film.Tytul,
                    }
                );
        }
        #endregion
    }
}
