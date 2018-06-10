using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;


namespace Konzultacije.Models
{
    [Table("Kolegij_profesor")]
    public class Kolegij_Profesor
    {
        [Column("id_profesor")]
        [Display(Name ="ID Profesor")]
        [ForeignKey("Profesor")]
        public int Id_profesor { get; set; }

        [Column("id_kolegij")]
        [Display(Name ="ID Kolegij")]
        [ForeignKey("Kolegij")]
        public int Id_kolegij { get; set; }

    }
}