﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CNC12.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CNCProjectEntities : DbContext
    {
        public CNCProjectEntities()
            : base("name=CNCProjectEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ChucVu> ChucVus { get; set; }
        public virtual DbSet<EventManagerCNC1> EventManagerCNC1 { get; set; }
        public virtual DbSet<EventManagerCNC2> EventManagerCNC2 { get; set; }
        public virtual DbSet<EventManagerCNC3> EventManagerCNC3 { get; set; }
        public virtual DbSet<EventManagerCNC4> EventManagerCNC4 { get; set; }
        public virtual DbSet<EventManagerCNC5> EventManagerCNC5 { get; set; }
        public virtual DbSet<EventManagerCNC6> EventManagerCNC6 { get; set; }
        public virtual DbSet<EventManagerCNC7> EventManagerCNC7 { get; set; }
        public virtual DbSet<EventManagerCNC8> EventManagerCNC8 { get; set; }
        public virtual DbSet<HienTrangCuaMayCNC> HienTrangCuaMayCNCs { get; set; }
        public virtual DbSet<HienTrangMayCNC> HienTrangMayCNCs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<OnlineStatu> OnlineStatus { get; set; }
    }
}
