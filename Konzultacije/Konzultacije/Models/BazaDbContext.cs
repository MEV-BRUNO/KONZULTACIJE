using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Konzultacije.Models
{
    public class BazaDbContext : DbContext
    {
        // Popis svih tablica u bazi
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Profesor> Profesor { get; set; }
        public virtual DbSet<Studij> Studij { get; set; }
        public virtual DbSet<Kolegij> Kolegij { get; set; }
        public virtual DbSet<Upit> Upit { get; set; }
        public virtual DbSet<Termini> Termini { get; set; }
        public virtual DbSet<Kolegij_Profesor> Kolegij_Profesor { get; set; }

    }
}