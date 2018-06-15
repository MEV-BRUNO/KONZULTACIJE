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

        [Display(Name ="ID Profesora")]
        public int ProfesorID { get; set; }
        public virtual Profesor Profesor { get; set; }
        public virtual ICollection<Profesor> Profesors { get; set; }

        [Display(Name ="ID Kolegija")]
        public int KolegijID { get; set; }
        public virtual Kolegij Kolegij { get; set; }
        public virtual ICollection<Kolegij> Kolegijs { get; set; }


    }
}