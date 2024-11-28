using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using MVVMFirma.Models.Entities;
using MVVMFirma.Helper;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{   //Jest to klasa, która odostarcza danych do widoku wyświetaljącego wszystkie towary.
    public class WszystkieTowaryViewModel : WszystkieViewModel<Towar>
    {
        
        #region Constructor
        public WszystkieTowaryViewModel()
            :base("Towary")
        {
        }
        #endregion
        #region Helpers
        //Metoda Load pobiera wszystkie towary z bazy danych.
        public override void Load()
        {
            List=new ObservableCollection<Towar>
                (kinoEntities.Towar.ToList()); //Z bazy danych pobiera Towar i wszystkie rekordy zamienia na listę.
        }
        #endregion
    }
}