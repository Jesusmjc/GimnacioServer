﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GimnacioDataAccess
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class GimnacioEntities : DbContext
    {
        public GimnacioEntities()
            : base("name=GimnacioEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Clases> Clases { get; set; }
        public virtual DbSet<Membresias> Membresias { get; set; }
        public virtual DbSet<Miembros> Miembros { get; set; }
        public virtual DbSet<MiembrosClases> MiembrosClases { get; set; }
        public virtual DbSet<Pagos> Pagos { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
    }
}
