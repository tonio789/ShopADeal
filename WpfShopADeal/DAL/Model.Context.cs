﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfShopADeal.DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class dbshopadealEntities : DbContext
    {
        public dbshopadealEntities()
            : base("name=dbshopadealEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<administra> administra { get; set; }
        public virtual DbSet<articulo> articulo { get; set; }
        public virtual DbSet<categoria> categoria { get; set; }
        public virtual DbSet<cesta> cesta { get; set; }
        public virtual DbSet<pedido> pedido { get; set; }
        public virtual DbSet<tienda> tienda { get; set; }
        public virtual DbSet<usuario> usuario { get; set; }
    }
}
