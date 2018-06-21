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
        public DbSet<Student> Student { get; set; }
        public DbSet<Profesor> Profesor { get; set; }
        public DbSet<Studij> Studij { get; set; }
        public DbSet<Kolegij> Kolegij { get; set; }
        public DbSet<Upit> Upit { get; set; }
        public DbSet<Termini> Termini { get; set; }
        public DbSet<Kolegij_Profesor> Kolegij_Profesor { get; set; }
        public DbSet<RegisterViewModel> Registracija { get; set; }

    }
}