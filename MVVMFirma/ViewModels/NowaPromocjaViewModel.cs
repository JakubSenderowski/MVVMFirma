﻿using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper;
using MVVMFirma.Models;
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
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public class NowaPromocjaViewModel:JedenViewModel<Promocja>, IDataErrorInfo
    {
        #region Konstruktor
        public NowaPromocjaViewModel()
           : base("Promocja")
        {
            item = new Promocja();
            Messenger.Default.Register<Film>(this, getWybranyFilm);
            Messenger.Default.Register<Bilet>(this, getWybranyBilet);
        }
        #endregion
        #region Command
        private BaseCommand _ShowFilmy; //Komenda, która będzie wywoływać funkcje (Wywołanie okna do dodawania, zostanie podpięta pod przycisk "Dodaj")

        public ICommand ShowFilmy
        {
            get
            {
                if (_ShowFilmy == null)
                    _ShowFilmy = new BaseCommand(() => showFilmy());
                return _ShowFilmy;
            }
        }
        private BaseCommand _ShowBilety; //Komenda, która będzie wywoływać funkcje (Wywołanie okna do dodawania, zostanie podpięta pod przycisk "Dodaj")

        public ICommand ShowBilety
        {
            get
            {
                if (_ShowBilety == null)
                    _ShowBilety = new BaseCommand(() => showBilety());
                return _ShowBilety;
            }
        }
        private void showFilmy()
        {
            Messenger.Default.Send<string>("FilmyAll");
        }
        private void showBilety()
        {
            Messenger.Default.Send<string>("BiletyAll");
        }
        #endregion
        public string FilmTytul { get; set; }
        public string BiletRodzaj { get; set; }
        #region Pola
        //Dla każdego pola na interface dodajmy properties.
        public String Nazwa
        {
            get
            {
                return item.Nazwa;
            }
            set
            {
                item.Nazwa = value;
                OnPropertyChanged(() => Nazwa);
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
        public decimal Rabat
        {
            get
            {
                return item.Rabat;
            }
            set
            {
                item.Rabat = value;
                OnPropertyChanged(() => Rabat);
            }
        }
        public DateTime DataRozpoczecia
        {
            get
            {
                return item.DataRozpoczecia;
            }
            set
            {
                item.DataRozpoczecia = value;
                OnPropertyChanged(() => DataRozpoczecia);
            }
        }
        public DateTime DataZakonczenia
        {
            get
            {
                return item.DataZakonczenia;
            }
            set
            {
                item.DataZakonczenia = value;
                OnPropertyChanged(() => DataZakonczenia);
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
        public int? BiletID
        {
            get
            {
                return item.BiletID;
            }
            set
            {
                item.BiletID = value;
                OnPropertyChanged(() => BiletID);
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
        public IQueryable<KeyAndValue> BiletItems
        {
            get
            {
                return new BiletB(KinoEntities).GetBiletKeyAndValueItems();
            }
        }
        #region Helpers
        #endregion
        private void getWybranyFilm(Film film)
        {
            FilmID = film.FilmID;
            FilmTytul = film.Tytul;
        }
        private void getWybranyBilet(Bilet bilet)
        {
            BiletID = bilet.BiletID;
            BiletRodzaj = bilet.TypBiletu;
        }
        public override void Save()
        {
            KinoEntities.Promocja.Add(item); //Dodanie towaru do lokalnej kolekcji.
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
                if (name == "Rabat")
                    komunikat = RabatValidator.SprawdzRabat(this.Rabat);
                return komunikat;
            }
        }

        public override bool IsValid()
        {
            if (this["Rabat"] == null) 
                return true;
            else
                return false;

        }
        #endregion


    }
}
