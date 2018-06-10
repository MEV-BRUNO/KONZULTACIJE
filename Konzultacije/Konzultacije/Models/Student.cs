using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;


namespace Konzultacije.Models
{
    [Table("Student")]
    public class Student
    {

        [Display(Name = "ID Studenta")]
        [Key]
        [Column("id_student")]
        public int Id_student { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage ="{0} je obavezan podatak")]
        [Column("ime_i_prezime")]
        public string Ime_I_Prezime { get; set; }

        public int Id_studij { get; set; }




        public string Email { get; set; }
        public string Lozinka { get; set;}
        public string Aktivacijski_link { get; set; }

        [Display(Name ="Aktivan")]
        [Column("aktivan")]
        public bool Aktivan { get; set; }

    }
}