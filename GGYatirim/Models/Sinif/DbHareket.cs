//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class DbHareket
    {
        public int HareketID { get; set; }
        public Nullable<System.DateTime> Tarih { get; set; }
        public Nullable<int> KullaniciIDD { get; set; }
        public Nullable<int> HaraketilanIDD { get; set; }
    
        public virtual Dbilan Dbilan { get; set; }
        public virtual DbKullanici DbKullanici { get; set; }
    }
}