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
    public class NowaStatystykaViewModel:JedenViewModel<Statystyki>
    {
        #region Konstruktor
        public NowaStatystykaViewModel()
           : base("Statystki")
        {
            item = new Statystyki();
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
        public int LiczbaSprzedanychBiletow
        {
            get
            {
                return item.LiczbaSprzedanychBiletow;
            }
            set
            {
                item.LiczbaSprzedanychBiletow = value;
                OnPropertyChanged(() => LiczbaSprzedanychBiletow);
            }
        }
        public decimal LacznyPrzychod
        {
            get
            {
                return item.LacznyPrzychod;
            }
            set
            {
                item.LacznyPrzychod = value;
                OnPropertyChanged(() => LacznyPrzychod);
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
        public IQueryable<KeyAndValue> FilmyItems
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
                return new SalaLiczbaMiejsc(KinoEntities).GetSalaLiczbaMiejscKeyAndValueItems();
            }
        }
        #endregion
        #region Helpers
        public override void Save()
        {
            KinoEntities.Statystyki.Add(item); //Dodanie towaru do lokalnej kolekcji.
            KinoEntities.SaveChanges(); //Zapisuje zmiany do bazy danych
        }

        #endregion
    }
}
