﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HomeworX.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HomeworXEntities : DbContext
    {
        public HomeworXEntities()
            : base("name=HomeworXEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Appointment> Appointment { get; set; }
        public virtual DbSet<Exam> Exam { get; set; }
        public virtual DbSet<Homework> Homework { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<Topic> Topic { get; set; }
        public virtual DbSet<TopicToAppointment> TopicToAppointment { get; set; }
    }
}
