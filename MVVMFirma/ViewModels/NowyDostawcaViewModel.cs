using MVVMFirma.Models.Entities;
using MVVMFirma.Models.Validatory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class NowyDostawcaViewModel:JedenViewModel<Dostawca>, IDataErrorInfo
    {

        public NowyDostawcaViewModel()
            : base("Dostawca")
        {
            item = new Dostawca();
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
        public String Telefon
        {
            get
            {
                return item.Telefon;
            }
            set
            {
                item.Telefon = value;
                OnPropertyChanged(() => Telefon);
            }
        }
        public String Email
        {
            get
            {
                return item.Email;
            }
            set
            {
                item.Email = value;
                OnPropertyChanged(() => Email);
            }

        }
        public override void Save()
        {
            KinoEntities.Dostawca.Add(item); //Dodanie towaru do lokalnej kolekcji.
            KinoEntities.SaveChanges(); //Zapisuje zmiany do bazy danych
        }
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
                if (name == "Telefon")
                    komunikat = TelefonValidator.SprawdzTelefon(this.Telefon);
                return komunikat;
            }
        }

        public override bool IsValid()
        {
            if (this["Telefon"] == null)
                return true;
            else
                return false;

        }
        #endregion
    }
}
