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
    internal class RaportSprzedazyTowarowViewModel:WorkspaceViewModel
    {
        #region DB
        KinoEntities db;
        #endregion
        #region Konstruktor
        public RaportSprzedazyTowarowViewModel()
        {
            base.DisplayName = "Raport Sprzedazy Towarow";
            db = new KinoEntities();
        }
        #endregion
        private int _TowarID;
        public int TowarID
        {
            get { return _TowarID; }
            set
            {
                if (_TowarID != value)
                {
                    _TowarID = value;
                    OnPropertyChanged(() => TowarID);
                }
            }
        }
        private decimal? _suma;
        public decimal? Suma
        {
            get { return _suma; }
            set
            {
                if (_suma != value)
                {
                    _suma = value;
                    OnPropertyChanged(() => Suma);
                }
            }
        }
        public IQueryable<KeyAndValue> TowarItems
        {
            get
            {
                return new TowarB(db).GetTowaryKeyAndValueItems();
            }
        }
        #region Komneda
        //To jest komenda, która zostanie podpięta pod przycisk Oblicz. Która wywoła obliczUtargKlik
        private BaseCommand _ObliczSumeCommand;
        public ICommand ObliczSumeCommand
        {
            get
            {
                if (_ObliczSumeCommand == null)
                    _ObliczSumeCommand = new BaseCommand(() => obliczSumeKlik());
                return _ObliczSumeCommand;
            }
        }
        private void obliczSumeKlik()
        {
            //To jest użycie funkcji z klasy logiki biznesowej, która liczy sumą za dany Tytuł Filmu w sprzedanych biletach.
            Suma = new SumaB(db).SumaCaloscTowar(TowarID);
        }
        #endregion
    }
}
