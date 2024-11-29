using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public abstract class JedenViewModel<T>:WorkspaceViewModel
    {
        #region DB
        protected KinoEntities KinoEntities;
        #endregion
        #region Item
        protected T item;
        #endregion
        #region Command
        //Komenda, która zostanie podpięta pod przycisk Zapisz (Wywoła ona funkcję Save)
        private BaseCommand _SaveCommand;
        public ICommand SaveCommand
        {
            get
            {
                if (_SaveCommand == null)
                    _SaveCommand = new BaseCommand(() => SaveAndClose());
                return _SaveCommand;
            }
        }
        #endregion
        #region Constructor
        public JedenViewModel(string displayName)
        {
            base.DisplayName = displayName;
            KinoEntities = new KinoEntities();
        
        }
        #endregion
        #region Helpers
        public abstract void Save();
        public void SaveAndClose()
        {
            Save();
            base.OnRequestClose();
        }
        #endregion
    }
}
