using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public class NowyTowarViewModel : JedenViewModel<Towar>
    {
        
        #region Constructor
        public NowyTowarViewModel()
            :base("Towar")
        {
            item = new Towar();
        }
        #endregion
        #region Properties
        //Dla każdego pola na Interfejsie tworzymy Properties.
        public String Kod
        {
            get { 
                return item.Kod;
            }
            set { 
            item.Kod = value;
                OnPropertyChanged(() => Kod);
            }
        }
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
        public decimal? StawkaVatZakupu
        {
            get
            {
                return item.StawkaVatZakupu;
            }
            set
            {
                item.StawkaVatZakupu = value;
                OnPropertyChanged(() => StawkaVatZakupu);
            }
        }
        public decimal? StawkaVatSprzedazy
        {
            get
            {
                return item.StawkaVatSprzedazy;
            }
            set
            {
                item.StawkaVatSprzedazy = value;
                OnPropertyChanged(() => StawkaVatSprzedazy);
            }
        }
        public decimal? Cena
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
        public decimal? Marza
        {
            get
            {
                return item.Marza;
            }
            set
            {
                item.Marza = value;
                OnPropertyChanged(() => Marza);
            }
        }
        #endregion
        #region Helpers
        public override void Save()
        { 
            KinoEntities.Towar.Add(item); //Dodanie towaru do lokalnej kolekcji.
            KinoEntities.SaveChanges(); //Zapisuje zmiany do bazy danych
        }
       
        #endregion

    }
}
