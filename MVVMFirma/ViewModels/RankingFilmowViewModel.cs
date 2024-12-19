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
    internal class RankingFilmowViewModel:WorkspaceViewModel
    {
        #region DB
        KinoEntities db;
        #endregion
        #region Konstruktor
        public RankingFilmowViewModel()
        {
            base.DisplayName = "Ranking Filmów";
            db = new KinoEntities();
        }
        #endregion
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
        private int? _ranking;
        public int? Ranking
        {
            get { return _ranking; }
            set
            {
                if (_ranking != value)
                {
                    _ranking = value;
                    OnPropertyChanged(() => _ranking);
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
        #region Komneda
        //To jest komenda, która zostanie podpięta pod przycisk Oblicz. Która wywoła obliczUtargKlik
        private BaseCommand _WyswietlCommand;
        public ICommand WyswietlCommand
        {
            get
            {
                if (_WyswietlCommand == null)
                    _WyswietlCommand = new BaseCommand(() => wyswietlRanking());
                return _WyswietlCommand;
            }
        }
        private void wyswietlRanking()
        {
            //To jest użycie funkcji z klasy logiki biznesowej, która liczy sumą za dany Tytuł Filmu w sprzedanych biletach.
            Ranking = new RankingB(db).LiczbaSprzedanychBiletowDlaFilmu(FilmID);
        }
        #endregion
    }
}
