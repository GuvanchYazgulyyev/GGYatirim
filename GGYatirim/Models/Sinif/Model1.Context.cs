﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GGYatirim.Models.Sinif
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class GYatirimEntities : DbContext
    {
        public GYatirimEntities()
            : base("name=GYatirimEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DbAdmin> DbAdmin { get; set; }
        public virtual DbSet<DbBlog> DbBlog { get; set; }
        public virtual DbSet<DbEmlakTipi> DbEmlakTipi { get; set; }
        public virtual DbSet<Dbilan> Dbilan { get; set; }
        public virtual DbSet<DbilanDurum> DbilanDurum { get; set; }
        public virtual DbSet<DbilanOzellik> DbilanOzellik { get; set; }
        public virtual DbSet<DbiletisimBilgi> DbiletisimBilgi { get; set; }
        public virtual DbSet<DbiletisimForm> DbiletisimForm { get; set; }
        public virtual DbSet<DbKonum> DbKonum { get; set; }
        public virtual DbSet<DbSlider> DbSlider { get; set; }
        public virtual DbSet<DbTemsilci> DbTemsilci { get; set; }
        public virtual DbSet<DbYetki> DbYetki { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<DbKullanici> DbKullanici { get; set; }
        public virtual DbSet<ialnlarDeneme> ialnlarDeneme { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ResimDeneme> ResimDeneme { get; set; }
        public virtual DbSet<DbilanGallery> DbilanGallery { get; set; }
        public virtual DbSet<DbHareket> DbHareket { get; set; }
        public virtual DbSet<tbl_il> tbl_il { get; set; }
        public virtual DbSet<tbl_ilce> tbl_ilce { get; set; }
        public virtual DbSet<tbl_mahalle> tbl_mahalle { get; set; }
        public virtual DbSet<tbl_semt> tbl_semt { get; set; }
    }
}
