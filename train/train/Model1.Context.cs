﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace train
{
    using System;
    using System.Data;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class z4_train_MihailovaEntities : DbContext
    {
        private static z4_train_MihailovaEntities baze;
        public z4_train_MihailovaEntities()
            : base("name=z4_train_MihailovaEntities")
        {

        }

        public static z4_train_MihailovaEntities getContext()
        {
            if (baze == null) { baze = new z4_train_MihailovaEntities(); }
            return baze;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<Executor> Executor { get; set; }
        public virtual DbSet<Manager> Manager { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Task> Task { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}