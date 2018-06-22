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
        [Key]
        [Display(Name = "ID Studenta")]
        [Column("id_student")]
        public int StudentID { get; set; }


        [Column("ime_i_prezime")]
        [Display(Name = "Ime i prezime")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        public string Ime_I_Prezime { get; set; }

        [Display(Name = "ID Studija")]
        [Column("id_studij")]
        [ForeignKey("Studij")]
        public int StudijID { get; set; }
        public virtual Studij Studij { get; set; }
        

        [Column("email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }


        [Column("lozinka")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [DataType(DataType.Password)]
        [Display(Name = "Lozinka")]
        [StringLength(25, ErrorMessage = "{0} mora imati najmanje {2} slova i najvise {1} slova.", MinimumLength = 5)]
        public string Lozinka { get; set; }


        [Column("aktivacijski_link")]
        [Display(Name = "Aktivacijski link")]
        [DataType(DataType.Url)]
        public string Aktivacijski_link { get; set; }


        [Column("aktivan")]
        [Display(Name = "Aktivan")]
        public bool Aktivan { get; set; }






        



    }
}