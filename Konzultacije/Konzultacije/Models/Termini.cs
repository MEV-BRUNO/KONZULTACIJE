using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Konzultacije.Models
{
    [Table("Termini")]
    public class Termini
    {

        [Display(Name = "ID Profesora")]
        [Key]
        [ForeignKey("Profesor")]
        public int ProfesorID { get; set; }
        public virtual Profesor Profesor { get; set; }
        public virtual ICollection<Profesor> Profesors { get; set; }

        [Display(Name ="ID Kolegija")]
        [Key]
        [ForeignKey("Kolegij")]
        public int KolegijID { get; set; }
        public virtual Kolegij Kolegij { get; set; }
        public virtual ICollection<Kolegij> Kolegijs { get; set; }


        [Column("dan_tjedan")]
        [Display(Name ="Datum termina")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage ="Niste popunili {0}.")]
        [DisplayFormat(DataFormatString ="{0} dd.MM.yyyy",ApplyFormatInEditMode = true)]
        public DateTime Dan_Tjedan { get; set; }

        [Column("vrijeme_od")]
        [Display(Name ="Vrijeme od")]
        [DisplayFormat(DataFormatString ="{0} hh:mm:ss", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Polje {0} je nepopunjeno.")]
        public DateTime Vrijeme_Od { get; set; }

        [Column("vrijeme_do")]
        [Display(Name ="Vrijeme do")]
        [DisplayFormat(DataFormatString ="{0} hh:mm:ss", ApplyFormatInEditMode =true)]
        [Required(ErrorMessage ="Polje {0} je nepopunjeno")]
        public DateTime Vrijeme_Do { get; set; }

    }
}