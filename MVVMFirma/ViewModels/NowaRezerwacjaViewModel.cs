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
    public class NowaRezerwacjaViewModel:JedenViewModel<Rezerwacja>
    {
        #region Konstruktor
        public NowaRezerwacjaViewModel()
           : base("Rezerwacja")
        {
            item = new Rezerwacja();
        }
        #endregion
        #region Pola
        //Dla każdego pola na interface dodajmy properties.
        public int? KlientID
        {
            get
            {
                return item.KlientID;
            }
            set
            {
                item.KlientID = value;
                OnPropertyChanged(() => KlientID);
            }
        }
        public DateTime DataRezerwacji
        {
            get
            {
                return item.DataRezerwacji;
            }
            set
            {
                item.DataRezerwacji = value;
                OnPropertyChanged(() => DataRezerwacji);
            }
        }
        public DateTime DataSeansu
        {
            get
            {
                return item.DataSeansu;
            }
            set
            {
                item.DataSeansu = value;
                OnPropertyChanged(() => DataSeansu);
            }
        }
        public int LiczbaBiletów
        {
            get
            {
                return item.LiczbaBiletów;
            }
            set
            {
                item.LiczbaBiletów = value;
                OnPropertyChanged(() => LiczbaBiletów);
            }
        }
        public String StatusRezerwacji
        {
            get
            { 
                return item.StatusRezerwacji;
            }
            set
            {
                item.StatusRezerwacji = value;
                OnPropertyChanged(() => StatusRezerwacji);
            }
        }
        #endregion
        #region WłaściwościDlaComboBoxów
        public IQueryable<KeyAndValue> KlientImieItems
        {
            get
            {
                return new KlientImie(KinoEntities).GetKlientImieKeyAndValueItems();
            }
        }
        public IQueryable<KeyAndValue> KlientNazwiskoItems
        {
            get
            {
                return new KlientNazwisko(KinoEntities).GetKlientNazwiskoKeyAndValueItems();
            }
        }
        public IQueryable<KeyAndValue> KlientEmailItems
        {
            get
            {
                return new KlientMail(KinoEntities).GetKlientMailKeyAndValueItems();
            }
        }
        public IQueryable<KeyAndValue> KlientTelefonItems
        {
            get
            {
                return new KlientNumer(KinoEntities).GetKlientNumerKeyAndValueItems();
            }
        }
        #endregion
        #region Helpers
        public override void Save()
        {
            KinoEntities.Rezerwacja.Add(item); //Dodanie towaru do lokalnej kolekcji.
            KinoEntities.SaveChanges(); //Zapisuje zmiany do bazy danych
        }

        #endregion
    }
}
