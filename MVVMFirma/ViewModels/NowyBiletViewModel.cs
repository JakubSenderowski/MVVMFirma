using MVVMFirma.Models.BusinessLogic;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class NowyBiletViewModel:JedenViewModel<Bilet>
    {
        #region Konstruktor
        public NowyBiletViewModel()
           : base("Bilet")
        {
            item = new Bilet();
        }
        #endregion
        #region Pola
        //Dla każdego pola na interface dodajmy properties.
        public Decimal Cena
        {
            get
            {
                return item.Cena;
            }
            set
            {
                item.Cena = value;
                OnPropertyChanged(() => Cena);
            }
        }

        public String TypBiletu
        {
            get
            {
                return item.TypBiletu;
            }
            set
            {
                item.TypBiletu = value;
                OnPropertyChanged(() => TypBiletu);
            }
        }
        public String Opis
        {
            get
            {
                return item.Opis;
            }
            set
            {
                item.Opis = value;
                OnPropertyChanged(() => Opis);
            }
        }
        public int? FilmID
        {
            get
            {
                return item.FilmID;
            }
            set
            {
                item.FilmID = value;
                OnPropertyChanged(() => FilmID);
            }
        }
        public IQueryable<KeyAndValue> FilmItems
        {
            get
            {
                return new FilmB(KinoEntities).GetFilmKeyAndValueItems();
            }
        }
        #endregion
        #region Helpers
        public override void Save()
        {
            KinoEntities.Bilet.Add(item); //Dodanie towaru do lokalnej kolekcji.
            KinoEntities.SaveChanges(); //Zapisuje zmiany do bazy danych
        }

        #endregion
    }
}
