﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FLovers.DAL.Repository.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FLoversEntities : DbContext
    {
        public FLoversEntities()
            : base("name=FLoversEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<AuditEvent> AuditEvents { get; set; }
        public virtual DbSet<CustomAuditEvent> CustomAuditEvents { get; set; }
        public virtual DbSet<EntityAuditEvent> EntityAuditEvents { get; set; }
    }
}
