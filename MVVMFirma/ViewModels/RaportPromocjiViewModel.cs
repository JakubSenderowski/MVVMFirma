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
    internal class RaportPromocjiViewModel:WorkspaceViewModel
    {
        #region DB
        KinoEntities db;
        #endregion
        #region Konstruktor
        public RaportPromocjiViewModel()
        {
            base.DisplayName = "Raport Promocji";
            db = new KinoEntities();
        }
        #endregion
        #region Pola
        //Dla każdego pola istostnego dla obliczeń, tworzymy pole i własciwość. 
        private int _FilmID;
        public int FilmID
        {
            get { return _FilmID; }
            set
            {
                if (_FilmID != value)
                {
                    _FilmID = value;
                    OnPropertyChanged(() => FilmID);
                }
            }
        }
        private DateTime _dataRozpoczecia;
        public DateTime DataRozpoczecia
        {
            get { return _dataRozpoczecia; }
            set
            {
                if (_dataRozpoczecia != value)
                {
                    _dataRozpoczecia = value;
                    OnPropertyChanged(() => DataRozpoczecia);
                }
            }
        }
        private DateTime _dataZakonczenia;
        public DateTime DataZakonczenia
        {
            get { return _dataZakonczenia; }
            set
            {
                if (_dataZakonczenia != value)
                {
                    _dataZakonczenia = value;
                    OnPropertyChanged(() => DataZakonczenia);
                }
            }
        }
        private List<String> _raport;
        public List<String> Raport
        {
            get { return _raport; }
            set
            {
                if (_raport != value)
                {
                    _raport = value;
                    OnPropertyChanged(() => Raport);
                }
            }
        }
        public IQueryable<KeyAndValue> FilmyItems
        {
            get
            {
                return new FilmB(db).GetFilmKeyAndValueItems();
            }
        }
        #endregion
        #region Komneda
        //To jest komenda, która zostanie podpięta pod przycisk Oblicz. Która wywoła obliczUtargKlik
        private BaseCommand _PokazCommand;
        public ICommand PokazCommand
        {
            get
            {
                if (_PokazCommand == null)
                    _PokazCommand = new BaseCommand(() => pokazKlik());
                return _PokazCommand;
            }
        }
        private void pokazKlik()
        {
            //To jest użycie funkcji z klasy logiki biznesowej, która liczy sumą za dany Tytuł Filmu w sprzedanych biletach.
            Raport = new RaportB(db).RaportOkresowy(FilmID, DataRozpoczecia, DataZakonczenia);
        }
        
        #endregion
    }
}
