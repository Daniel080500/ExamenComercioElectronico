using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ExamenComercioElectronico.Models
{
    public class BdExamenComercioElectronico : DbContext
    {
        public BdExamenComercioElectronico()
        {

        }

        public DbSet<Departamentos> Departamentos { get; set; }
        public DbSet<Funcionarios> Funcionarios { get; set; }
        public DbSet<Activos> Activos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}