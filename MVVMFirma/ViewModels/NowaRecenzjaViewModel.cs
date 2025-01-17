using MVVMFirma.Models.BusinessLogic;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using MVVMFirma.Models.Validatory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class NowaRecenzjaViewModel:JedenViewModel<Recenzja>, IDataErrorInfo
    {
        #region Konstruktor
        public NowaRecenzjaViewModel()
           : base("Recenzja")
        {
            item = new Recenzja();
        }
        #endregion
        #region Pola
        //Dla każdego pola na interface dodajmy properties.
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
        public String Autor
        {
            get
            {
                return item.Autor;
            }
            set
            {
                item.Autor = value;
                OnPropertyChanged(() => Autor);
            }
        }
        public int Ocena
        {
            get
            {
                return item.Ocena;
            }
            set
            {
                item.Ocena = value;
                OnPropertyChanged(() => Ocena);
            }
        }
        public String Komentarz
        {
            get
            {
                return item.Komentarz;
            }
            set
            {
                item.Komentarz = value;
                OnPropertyChanged(() => Komentarz);
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
        #endregion
        #region Helpers
        public override void Save()
        {
            KinoEntities.Recenzja.Add(item); //Dodanie towaru do lokalnej kolekcji.
            KinoEntities.SaveChanges(); //Zapisuje zmiany do bazy danych
        }

        #endregion
        #region Validation
        public string Error
        {
            get

            {
                return null;
            }
        }
        public string this[string name]
        {
            get
            {
                string komunikat = null;
                if (name == "Ocena")
                    komunikat = OcenyValidator.SprawdzOcene(this.Ocena);
                return komunikat;
            }
        }

        public override bool IsValid()
        {
            if (this["Ocena"] == null)
                return true;
            else
                return false;

        }
        #endregion
    }
}
