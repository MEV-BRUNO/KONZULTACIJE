using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Konzultacije.Models
{
    [Table("Kolegij")]
    public class Kolegij
    {
        [Key]
        [Column("id_kolegij")]
        [Display(Name ="ID Kolegija")]
        public int KolegijID { get; set; }


        [Column("naziv")]
        [Display(Name ="Naziv kolegija")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak.")]
        public string Naziv { get; set; }

        public virtual ICollection<Kolegij_Profesor> Kolegij_Profesors { get; set; }
        public virtual ICollection<Termini> Terminis { get; set; }
        public virtual ICollection<Upit> Upits { get; set; }
    }
}