﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JobPortal.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class JobDatabaseEntities : DbContext
    {
        public JobDatabaseEntities()
            : base("name=JobDatabaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
    }
}