//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MegaInventory.InventoryModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class IssuedDetail
    {
        public int MasterCode { get; set; }
        public string ItemCode { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
    
        public virtual Issued Issued { get; set; }
        public virtual Item Item { get; set; }
    }
}
