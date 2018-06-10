using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Konzultacije.Models
{
    [Table("Studij")]
    public class Studij
    {
        [Column("id_studij")]
        [Display(Name ="ID Studija")]
        [Key]
        public int Id_studij { get; set; }


        [Column("naziv")]
        [Display(Name ="Naziv studija")]
        [Required(AllowEmptyStrings = false, ErrorMessage ="{0} je obavezan podatak.")]
        public string Naziv { get; set; }

    }
}