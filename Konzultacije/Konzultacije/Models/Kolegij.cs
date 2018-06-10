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
        [Column("id_kolegij")]
        [Display(Name ="ID Kolegija")]
        [Key]
        public int Id_kolegij { get; set; }


        [Column("naziv")]
        [Display(Name ="Naziv kolegija")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak.")]
        public string Naziv { get; set; }
    }
}