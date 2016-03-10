//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MegaCastings.DBLib
{
    using System;
    using System.Collections.Generic;
    
    public partial class CastingOffer
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Reference { get; set; }
        public System.DateTime StartingDate { get; set; }
        public byte PostNumber { get; set; }
        public string Location { get; set; }
        public string PostDescription { get; set; }
        public string ProfileDescription { get; set; }
        public string Contact { get; set; }
        public int ClientId { get; set; }
        public Nullable<short> ProfessionFieldId { get; set; }
        public byte ContractTypeId { get; set; }
        public Nullable<short> ProfessionId { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual ContractType ContractType { get; set; }
        public virtual Profession Profession { get; set; }
        public virtual ProfessionField ProfessionField { get; set; }
    }
}
