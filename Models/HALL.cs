//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MultiplexBookingWebAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class HALL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HALL()
        {
            this.HALL_CAPACITY = new HashSet<HALL_CAPACITY>();
            this.MAGAZINEs = new HashSet<MAGAZINE>();
            this.SHOWs = new HashSet<SHOW>();
        }
    
        public int HallID { get; set; }
        public string HallDescription { get; set; }
        public Nullable<int> TotalCapacity { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HALL_CAPACITY> HALL_CAPACITY { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MAGAZINE> MAGAZINEs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SHOW> SHOWs { get; set; }
    }
}