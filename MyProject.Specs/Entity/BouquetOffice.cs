//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyProject.Specs.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class BouquetOffice
    {
        public string OfficeCode { get; set; }
        public string SalesChannelID { get; set; }
        public string ParentSalesChannelID { get; set; }
        public string BouquetPrefix { get; set; }
        public string CountryID { get; set; }
        public Nullable<System.DateTime> InsertedOn { get; set; }
        public Nullable<System.Guid> InsertedBy { get; set; }
        public string InsertedByName { get; set; }
        public Nullable<int> StrokeStructure { get; set; }
        public Nullable<System.DateTime> DeletedOn { get; set; }
        public Nullable<System.Guid> DeletedBy { get; set; }
        public string DeletedByName { get; set; }
        public System.Guid GenisysID { get; set; }
        public string LUCPayoutStructure { get; set; }
        public bool IsCashEnabled { get; set; }
    
        public virtual Office Office { get; set; }
    }
}
