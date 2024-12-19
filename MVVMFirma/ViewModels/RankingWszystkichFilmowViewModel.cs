using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    internal class RankingWszystkichFilmowViewModel:WorkspaceViewModel
    {
        #region DB
        KinoEntities db;
        #endregion
        #region Konstruktor
        public RankingWszystkichFilmowViewModel()
        {
            base.DisplayName = "Ranking Filmow";
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
        private int _minOcena;
        public int MinOcena
        {
            get { return _minOcena; }
            set
            {
                if (_minOcena != value)
                {
                    _minOcena = value;
                    OnPropertyChanged(() => MinOcena);
                }
            }
        }

        private int _maxOcena;
        public int MaxOcena
        {
            get { return _maxOcena; }
            set
            {
                if (_maxOcena != value)
                {
                    _maxOcena = value;
                    OnPropertyChanged(() => MaxOcena);
                }
            }
        }
    }
}
