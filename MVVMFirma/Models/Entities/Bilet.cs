//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVVMFirma.Models.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bilet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bilet()
        {
            this.Promocja = new HashSet<Promocja>();
        }
    
        public int BiletID { get; set; }
        public decimal Cena { get; set; }
        public string TypBiletu { get; set; }
        public string Opis { get; set; }
        public Nullable<int> FilmID { get; set; }
    
        public virtual Film Film { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Promocja> Promocja { get; set; }
    }
}
