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
    
    public partial class Repertuar
    {
        public int RepertuarID { get; set; }
        public System.DateTime Data { get; set; }
        public string GodzinySeansow { get; set; }
        public Nullable<int> FilmID { get; set; }
        public Nullable<int> SalaID { get; set; }
    
        public virtual Film Film { get; set; }
        public virtual Sala Sala { get; set; }
    }
}
