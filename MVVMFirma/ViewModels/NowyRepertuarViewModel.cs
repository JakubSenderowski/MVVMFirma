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
    public class NowyRepertuarViewModel:JedenViewModel<Repertuar>
    {
        #region Konstruktor
        public NowyRepertuarViewModel()
           : base("Repertuar")
        {
            item = new Repertuar();
        }
        #endregion
        #region Pola
        //Dla każdego pola na interface dodajmy properties.
        public DateTime Data
        {
            get
            {
                return item.Data;
            }
            set
            {
                item.Data = value;
                OnPropertyChanged(() => Data);
            }
        }
        public String GodzinySeansow
        {
            get
            {
                return item.GodzinySeansow;
            }
            set
            {
                item.GodzinySeansow = value;
                OnPropertyChanged(() => GodzinySeansow);
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
        public int? SalaID
        {
            get
            {
                return item.SalaID;
            }
            set
            {
                item.SalaID = value;
                OnPropertyChanged(() => SalaID);
            }
        }
        #endregion
        #region WłaściwościDlaComboBoxów
        public IQueryable<KeyAndValue> FilmItems
        {
            get
            {
                return new FilmB(KinoEntities).GetFilmKeyAndValueItems();
            }
        }
        public IQueryable<KeyAndValue> SalaItems
        {
            get
            {
                return new SalaB(KinoEntities).GetSalaKeyAndValueItems();
            }
        }
        #endregion
        #region Helpers
        public override void Save()
        {
            KinoEntities.Repertuar.Add(item); //Dodanie towaru do lokalnej kolekcji.
            KinoEntities.SaveChanges(); //Zapisuje zmiany do bazy danych
        }

        #endregion
    }
}
