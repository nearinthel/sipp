﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using Entities;
    
    public partial class AlacartaEntities : DbContext
    {
        public AlacartaEntities()
            : base("name=AlacartaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Articulo> Articulo { get; set; }
        public DbSet<ArticuloLocal> ArticuloLocal { get; set; }
        public DbSet<Descuento> Descuento { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Especificacion> Especificacion { get; set; }
        public DbSet<EspecificacionLocal> EspecificacionLocal { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Local> Local { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Ubicacion> Ubicacion { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Valoracion> Valoracion { get; set; }
    }
}