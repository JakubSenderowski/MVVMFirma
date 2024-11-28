using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public abstract class WszystkieViewModel<T>:WorkspaceViewModel // Pod "T" podstawieane są konkretne typy elementów listy.
    {
        #region DB
        protected readonly KinoEntities kinoEntities; // Pole, które repreztenutje bazę danych.
        #endregion
        #region LoadCommand
        private BaseCommand _LoadCommand; //Komenda, która będzie wywoływać funkcj (Pobierająca z bazy danych towar)

        public ICommand LoadCommand
        {
            get
            {
                if (_LoadCommand == null)
                    _LoadCommand = new BaseCommand(() => Load());
                return _LoadCommand;
            }
        }
        #endregion
        #region List
        private ObservableCollection<T> _List;
        public ObservableCollection<T> List
        {
            get
            {
                if (_List == null)
                    Load();
                return _List;
            }
            set
            {
                _List = value;
                OnPropertyChanged(() => List);
            }
        }
        #endregion
        #region Constructor



        public WszystkieViewModel(String displayName)
        {
           
            kinoEntities = new KinoEntities();
            base.DisplayName = displayName;
        }
        #endregion
        #region Helpers
        public abstract void Load(); // Metoda Load pobiera wszystkie towary z bazy danych.
        #endregion
    }
}
