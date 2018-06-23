using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Konzultacije.Models
{
    [Table("Upit")]
    public class Upit
    {
        [Key]
        [Column("id_upit")]
        [Display(Name = "ID Upita")]
        public int UpitID { get; set; }

        
        [Display(Name ="ID Studenta")]
        [Column("id_student")]
        [ForeignKey("Student")]
        public int StudentID { get; set; }
        public virtual Student Student { get; set; }

        [Display(Name ="ID Profesora")]
        [Column("id_profesor")]
        [ForeignKey("Profesor")]
        public int ProfesorID { get; set; }
        public virtual Profesor Profesor { get; set; }
        
        


        [Column("datum")]
        [Display(Name = "Datum upita")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0: hh:mm:ss dd.MM.yyyy.}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "{0} je obavezno polje.")]
        public DateTime Datum { get; set; }


        [Column("naslov")]
        [Display(Name = "Naslov")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezno polje.")]
        public string Naslov { get; set; }


        [Column("opis")]
        [Display(Name = "Opis")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezno polje.")]
        public string Opis { get; set; }


        [Column("dogovoren")]
        [Display(Name = "Dogovoreno")]
        public bool Odgovoren { get; set; }

    }
}