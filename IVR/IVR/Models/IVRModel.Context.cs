﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IVR.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class IVRDBEntities2 : DbContext
    {
        public IVRDBEntities2()
            : base("name=IVRDBEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Course> Course { get; set; }
        public DbSet<Prerequisites> Prerequisites { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<sysdiagrams> sysdiagrams { get; set; }
        public DbSet<TimeTable> TimeTable { get; set; }
        public DbSet<SystemUser> SystemUser { get; set; }
    }
}
