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
    
    public partial class FOOD
    {
        public int FoodID { get; set; }
        public Nullable<int> UserID { get; set; }
        public string FoodItems { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<double> Price { get; set; }
    
        public virtual USER USER { get; set; }
    }
}