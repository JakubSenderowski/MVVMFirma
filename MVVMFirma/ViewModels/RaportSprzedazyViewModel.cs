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
    public class RaportSprzedazyViewModel:WorkspaceViewModel
    {
        #region DB
        KinoEntities db;
        #endregion
        #region Konstruktor
        public RaportSprzedazyViewModel()
        {
            base.DisplayName = "Raport Sprzedazy";
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
                    OnPropertyChanged(() =>  FilmID);
                }
            }
        }
        private double? _utarg;
        public double? Utarg
        {
            get { return _utarg; }
            set
            {
                if (_utarg != value)
                {
                    _utarg = value;
                    OnPropertyChanged(() => Utarg);
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
        private BaseCommand _ObliczCommand;
        public ICommand ObliczCommand
        {
            get 
            {
                if (_ObliczCommand == null)
                    _ObliczCommand = new BaseCommand(() => obliczUtargKlik());
                return _ObliczCommand;
            }
        }
        private void obliczUtargKlik()
        { 
            //To jest użycie funkcji z klasy logiki biznesowej, która liczy sumą za dany Tytuł Filmu w sprzedanych biletach.
            Utarg = new UtargB(db).UtargOkresTowar(FilmID);
        }
        #endregion
    }
}
