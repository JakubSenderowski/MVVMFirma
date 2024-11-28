using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public class NowyTowarViewModel : WorkspaceViewModel
    {
        #region DB
        private KinoEntities KinoEntities;
        #endregion
        #region Item
        private Towar towar;
        #endregion
        #region Command
        //Komenda, która zostanie podpięta pod przycisk Zapisz (Wywoła ona funkcję Save)
        private BaseCommand _SaveCommand;
        public ICommand SaveCommand
        { 
            get
            {
                if (_SaveCommand == null)
                    _SaveCommand = new BaseCommand(() => Save());
                return _SaveCommand;
            }
        }
        #endregion
        #region Constructor
        public NowyTowarViewModel()
        {
            base.DisplayName = "Towar";
            KinoEntities = new KinoEntities();
            towar = new Towar();
        }
        #endregion
        #region Properties
        //Dla każdego pola na Interfejsie tworzymy Properties.
        public String Kod
        {
            get { 
                return towar.Kod;
            }
            set { 
            towar.Kod = value;
                OnPropertyChanged(() => Kod);
            }
        }
        public String Nazwa
        {
            get
            {
                return towar.Nazwa;
            }
            set
            {
                towar.Nazwa = value;
                OnPropertyChanged(() => Nazwa);
            }
        }
        public decimal? StawkaVatZakupu
        {
            get
            {
                return towar.StawkaVatZakupu;
            }
            set
            {
                towar.StawkaVatZakupu = value;
                OnPropertyChanged(() => StawkaVatZakupu);
            }
        }
        public decimal? StawkaVatSprzedazy
        {
            get
            {
                return towar.StawkaVatSprzedazy;
            }
            set
            {
                towar.StawkaVatSprzedazy = value;
                OnPropertyChanged(() => StawkaVatSprzedazy);
            }
        }
        public decimal? Cena
        {
            get
            {
                return towar.Cena;
            }
            set
            {
                towar.Cena = value;
                OnPropertyChanged(() => Cena);
            }
        }
        public decimal? Marza
        {
            get
            {
                return towar.Marza;
            }
            set
            {
                towar.Marza = value;
                OnPropertyChanged(() => Marza);
            }
        }
        #endregion
        #region Helpers
        public void Save()
        {
            KinoEntities.Towar.Add(towar); // Dodaje towar to lokalnej kolekcji.
            KinoEntities.SaveChanges(); //Zapisuje zmiany do bazy danych
        }
        #endregion

    }
}
