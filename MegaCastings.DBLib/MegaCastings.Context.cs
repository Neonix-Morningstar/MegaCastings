﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MegaCastingsEntities : DbContext
    {
        public MegaCastingsEntities()
            : base("name=MegaCastingsEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CastingOffer> CastingOffers { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ContractType> ContractTypes { get; set; }
        public virtual DbSet<Profession> Professions { get; set; }
        public virtual DbSet<ProfessionField> ProfessionFields { get; set; }
    }
}
