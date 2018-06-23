using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;


namespace Konzultacije.Models
{

    public class LoginViewModel
    {

        [Display(Name = "E-Adresa")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Lozinka")]
        public string Lozinka { get; set; }
  }

    public class ForgottenPasswordViewModel
    {
        [Display(Name = "E-Adresa")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

    }

    
    
}