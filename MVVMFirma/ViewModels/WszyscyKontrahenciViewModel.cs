using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class WszyscyKontrahenciViewModel:WszystkieViewModel<Kontrahent>
    {
        public WszyscyKontrahenciViewModel()
            : base("Kontrahenci")
        { 
        }
        #region Properties
        //Do Properties zostanie przypisany kontrahent kliknięty na liście.
        private Kontrahent _WybranyKontrahent;
        public Kontrahent WybranyKontrahent 
        
        { 
            get 
            {
                return _WybranyKontrahent;
            }

            set 
            {  
                _WybranyKontrahent = value;
                //Messengerem wysyłamy wybranego kontrahenta do okna z fakturą. (Tam będzie odebrany, potem zamykamy okno po wybraniu)
                Messenger.Default.Send(_WybranyKontrahent);
                OnRequestClose();
            }
        }

        #endregion
        public override void Load()
        {
            List = new ObservableCollection<Kontrahent>
                (kinoEntities.Kontrahent.ToList()); //Z bazy danych pobiera Towar i wszystkie rekordy zamienia na listę.
        }
    }
}
