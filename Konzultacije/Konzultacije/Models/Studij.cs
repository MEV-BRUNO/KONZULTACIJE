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

        [Display(Name = "ID Studija")]
        public int StudijID { get; set; }


        [Column("naziv")]
        [Display(Name = "Naziv studija")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak.")]
        public string Naziv { get; set; }

        public virtual Student Student { get; set; }
        public virtual ICollection<Student> Students { get; set; }

    }
}