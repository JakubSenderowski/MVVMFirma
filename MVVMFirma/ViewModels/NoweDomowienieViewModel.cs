using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class NoweDomowienieViewModel:JedenViewModel<Domowienia>
    {
        public NoweDomowienieViewModel()
            : base("Domowienia")
        {
            item = new Domowienia();
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
        public int? TowarID
        {
            get
            {
                return item.TowarID;
            }
            set
            {
                item.TowarID = value;
                OnPropertyChanged(() => TowarID);
            }
        }

        public int? Ilosc
        {
            get
            {
                return item.Ilosc;
            }
            set
            {
                item.Ilosc = value;
                OnPropertyChanged(() => Ilosc);
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

        public override void Save()
        {
            KinoEntities.Domowienia.Add(item); //Dodanie towaru do lokalnej kolekcji.
            KinoEntities.SaveChanges(); //Zapisuje zmiany do bazy danych
        }
    }
}
