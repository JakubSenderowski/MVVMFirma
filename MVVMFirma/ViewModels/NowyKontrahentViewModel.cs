using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class NowyKontrahentViewModel:JedenViewModel<Kontrahent>
    {
        public NowyKontrahentViewModel()
            : base("Kontrahent")
        {
            item = new Kontrahent();
        }
        public String Kod
        {
            get
            {
                return item.Kod;
            }
            set
            {
                item.Kod = value;
                OnPropertyChanged(() => Kod);
            }
        }
        public String NIP
        {
            get
            {
                return item.NIP;
            }
            set
            {
                item.NIP = value;
                OnPropertyChanged(() => NIP);
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
        public int? IdRodzaju
        {
            get
            {
                return item.IdRodzaju;
            }
            set
            {
                item.IdRodzaju = value;
                OnPropertyChanged(() => IdRodzaju);
            }
        }
        public int? IdStatusu
        {
            get
            {
                return item.IdStatusu;
            }
            set
            {
                item.IdStatusu = value;
                OnPropertyChanged(() => IdStatusu);
            }
        }
        public int? IdAdresu
        {
            get
            {
                return item.IdAdresu;
            }
            set
            {
                item.IdAdresu = value;
                OnPropertyChanged(() => IdAdresu);
            }
        }

        public override void Save()
        {
            KinoEntities.Kontrahent.Add(item); //Dodanie towaru do lokalnej kolekcji.
            KinoEntities.SaveChanges(); //Zapisuje zmiany do bazy danych
        }
    }
}
