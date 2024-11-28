using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class NowaFakturaViewModel:WorkspaceViewModel // Ponieważ wszystkie zakładki dziedziczą po WorkSpaceVM.
    {
        public NowaFakturaViewModel() {
            base.DisplayName = "Faktura";
        }
    }
}
