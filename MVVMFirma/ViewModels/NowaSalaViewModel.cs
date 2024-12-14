using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class NowaSalaViewModel:JedenViewModel<Sala>
    {
        public NowaSalaViewModel()
           : base("Sala")
        {
            item = new Sala();
        }
        public int NumerSali
        {
            get
            {
                return item.NumerSali;
            }
            set
            {
                item.NumerSali = value;
                OnPropertyChanged(() => NumerSali);
            }
        }
        public int LiczbaMiejsc
        {
            get
            {
                return item.LiczbaMiejsc;
            }
            set
            {
                item.LiczbaMiejsc = value;
                OnPropertyChanged(() => LiczbaMiejsc);
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
        public override void Save()
        {
            KinoEntities.Sala.Add(item); //Dodanie towaru do lokalnej kolekcji.
            KinoEntities.SaveChanges(); //Zapisuje zmiany do bazy danych
        }
    }
}
