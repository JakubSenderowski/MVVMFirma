using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper;
using MVVMFirma.Models.BusinessLogic;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public class NowaFakturaViewModel:JedenViewModel<Faktura>
    {
        #region Konstruktor
        public NowaFakturaViewModel()
           : base("Faktura")
        {
            item = new Faktura();
            //Messenger, który oczekuje na kontrahenta z widoku ze Wszystkimi kontrahentami
            //Kiedy jest "Złapany", wywoływana jest metoda getWybranyKontrahent
            Messenger.Default.Register<Kontrahent>(this, getWybranyKontrahent);
        }
        #endregion
        #region Command
        private BaseCommand _ShowKontrahenci;
        public ICommand ShowKontrahenci
        {
            get
            {
                if (_ShowKontrahenci == null)
                    _ShowKontrahenci = new BaseCommand(() => showKontrahenci());
                return _ShowKontrahenci;
            }
        }
        private void showKontrahenci()
        {
            Messenger.Default.Send<string>("KontrahenciAll");
        }
        #endregion
        #region Pola
        //Dla każdego pola na interface dodajmy properties.
        public String Numer
        {
            get
            {
                return item.Numer;
            }
            set
            {
                item.Numer = value;
                OnPropertyChanged(() => Numer);
            }
        }

        public DateTime DataWystawienia
        {
            get
            {
                return item.DataWystawienia;
            }
            set
            {
                item.DataWystawienia = value;
                OnPropertyChanged(() => DataWystawienia);
            }
        }
        public int IdKontrahenta
        {
            get
            {
                return item.IdKontrahenta;
            }
            set
            {
                item.IdKontrahenta = value;
                OnPropertyChanged(() => IdKontrahenta);
            }
        }

        public string KontrahentNazwa { get; set; }
        public string KontrahentNIP { get; set; }
        public DateTime TerminPlatnosci
        {
            get
            {
                return item.TerminPlatnosci;
            }
            set
            {
                item.TerminPlatnosci = value;
                OnPropertyChanged(() => TerminPlatnosci);
            }
        }
        public int IdSposobuPlatnosci
        {
            get
            {
                return item.IdSposobuPlatnosci;
            }
            set
            {
                item.IdSposobuPlatnosci = value;
                OnPropertyChanged(() => IdSposobuPlatnosci);
            }
        }
        public int? DostawcaID
        {
            get
            {
                return item.DostawcaID;
            }
            set
            {
                item.DostawcaID = value;
                OnPropertyChanged(() => DostawcaID);
            }
        }
        #endregion
        #region WłaściwościDlaComboBoxów
        public IQueryable<KeyAndValue> KontrahenciItems 
        { 
            get
            {
                return new KontrahenciB(KinoEntities).GetKontrahenciKeyAndValueItems();
            }
        }
        public IQueryable<KeyAndValue> SposobyPlatnosciItems
        {
            get
            {
                return new SposobyPlatnosciB(KinoEntities).GetSposobyPlatnosciKeyAndValueItems();

            }
        }
        public IQueryable<KeyAndValue> DostawcaItems
        {
            get
            {
                return new DostawcaB(KinoEntities).GetDostawcyKeyAndValueItems();

            }
        }
        #endregion
        #region Helpers

        private void getWybranyKontrahent(Kontrahent kontrahent)
        {
            IdKontrahenta = kontrahent.IdKontrahenta;
            KontrahentNazwa = kontrahent.Nazwa;
            KontrahentNIP = kontrahent.NIP;
        }
        public override void Save()
        {
            KinoEntities.Faktura.Add(item); //Dodanie towaru do lokalnej kolekcji.
            KinoEntities.SaveChanges(); //Zapisuje zmiany do bazy danych
        }

        #endregion
    }
}
