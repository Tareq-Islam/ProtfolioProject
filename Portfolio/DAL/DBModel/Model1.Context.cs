﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL.DBModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class portfolioEntity : DbContext
    {
        public portfolioEntity()
            : base("name=portfolioEntity")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<CategoryMGRef> CategoryMGRef { get; set; }
        public virtual DbSet<MediaGallery> MediaGallery { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductMGRef> ProductMGRef { get; set; }
    }
}
