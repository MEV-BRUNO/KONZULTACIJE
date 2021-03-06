﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Konzultacije.Models
{
    [Table("Profesor")]
    public class Profesor
    {

        [Key]       
        [Display(Name ="ID Profesora")]
        [Column("id_profesor")]
        public int ProfesorID { get; set; }


        [Column("ime_i_prezime")]
        [Display(Name ="Ime i prezime")]
        [Required(AllowEmptyStrings = false, ErrorMessage ="{0} j eobavezan podatak.")]
        public string Ime_I_Prezime { get; set; }

        [Column("email")]
        [EmailAddress]
        [Display(Name ="Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Column("lozinka")]
        [Display(Name ="Lozinka")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak.")]
        [StringLength(25, ErrorMessage ="{0} ne moze imati manje od {2} niti vise od {1} slova.", MinimumLength = 7)]
        [DataType(DataType.Password)]
        public string Lozinka { get; set; }


        [Column("aktivacijski_link")]
        [Display(Name ="Aktivacijski link")]
        [DataType(DataType.Url)]
        public string Aktivacijski_Link { get; set; }


        [Column("aktivan")]
        [Display(Name ="Aktivan")]
        public bool Aktivan { get; set; }

        public virtual ICollection<Kolegij_Profesor> Kolegij_Profesors { get; set; }
        public virtual ICollection<Termini> Terminis { get; set; }
        public virtual ICollection<Upit> Upits { get; set; }
            
    }
}