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
        
        [Display(Name = "ID Profesor")]
        public int ProfesorID { get; set; }
        public virtual Profesor Profesor{ get; set; }
        public virtual ICollection<Profesor> Profesors { get; set; }

        [Column("id_kolegij")]
        [Display(Name ="ID Kolegij")]
        public int KolegijID { get; set; }

    }
}