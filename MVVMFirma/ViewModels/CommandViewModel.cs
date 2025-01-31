using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public class CommandViewModel : BaseViewModel
    {
        #region Properties
        public string DisplayName { get; }  // Nazwa komendy do wyświetlenia
        public ICommand Command { get; }    // Komenda do wykonania
        public string Icon { get; }         // Ścieżka do ikony
        #endregion

        #region Constructor
        public CommandViewModel(string displayName, ICommand command, string icon = null)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command)); // Poprawna forma użycia ArgumentNullException

            DisplayName = displayName;
            Command = command;
            Icon = icon; // Może być null, jeśli ikona nie jest wymagana
        }
        #endregion
    }
}