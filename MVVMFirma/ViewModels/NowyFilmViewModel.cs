using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class NowyFilmViewModel: JedenViewModel<Film>
    {
        public NowyFilmViewModel()
            : base("Film")
        { 
            item = new Film();
        }
        public String Tytul
        {
            get
            {
                return item.Tytul;
            }
            set
            {
                item.Tytul = value;
                OnPropertyChanged(() => Tytul);
            }
        }
        public TimeSpan CzasTrwania
        {
            get
            {
                return item.CzasTrwania;
            }
            set
            {
                item.CzasTrwania = value;
                OnPropertyChanged(() => CzasTrwania);
            }
        }
        public string Opis
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
            KinoEntities.Film.Add(item); //Dodanie towaru do lokalnej kolekcji.
            KinoEntities.SaveChanges(); //Zapisuje zmiany do bazy danych
        }
    }
}
