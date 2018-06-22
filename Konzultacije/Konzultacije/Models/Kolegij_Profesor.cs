using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Konzultacije.Models
{
    [Table("Kolegij_profesor")]
    public class Kolegij_Profesor
    {
        [Display(Name ="Kolegij_Profesor ID")]
        [Key]
        [Column("id_kolegij_profesor")]
        public int Kolegij_ProfesorID { get; set; }

        [Display(Name ="ID Profesora")]
        [Column("id_profesor")]
        [ForeignKey("Profesor")]
        public int ProfesorID { get; set; }
        public virtual Profesor Profesor { get; set; }
        

        [Display(Name ="ID Kolegija")]
        [Column("id_kolegij")]
        [ForeignKey("Kolegij")]
        public int KolegijID { get; set; }
        public virtual Kolegij Kolegij { get; set; }
        


    }
}