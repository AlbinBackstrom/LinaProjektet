//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LINAprojektet
{
    using System;
    using System.Collections.Generic;
    
    public partial class Medfinansiar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Medfinansiar()
        {
            this.MedfinansiarProjekt = new HashSet<MedfinansiarProjekt>();
        }
    
        public int ID { get; set; }
        public string Namn { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MedfinansiarProjekt> MedfinansiarProjekt { get; set; }
    }
}