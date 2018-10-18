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
    
    public partial class ReturnToSupplier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ReturnToSupplier()
        {
            this.ReturnToSupplierDetails = new HashSet<ReturnToSupplierDetail>();
        }
    
        public int Id { get; set; }
        public System.DateTime ReturnDate { get; set; }
        public string Reference { get; set; }
        public string ApplicantCode { get; set; }
        public string ApproverCode { get; set; }
        public Nullable<int> ProjectId { get; set; }
        public string Remark { get; set; }
        public string ComputerCode { get; set; }
        public System.DateTime ComputeTime { get; set; }
    
        public virtual Employee Approver { get; set; }
        public virtual Employee Applicant { get; set; }
        public virtual Employee Computer { get; set; }
        public virtual Project Project { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReturnToSupplierDetail> ReturnToSupplierDetails { get; set; }
    }
}