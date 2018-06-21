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
       [Required]
       [Display(Name = "E-Adresa")]
       [DataType(DataType.EmailAddress)]
       public string Email { get; set; }

      [Required]
      [DataType(DataType.Password)]
      [Display(Name = "Lozinka")]
      public string Lozinka { get; set; }
  }

    public class ForgottenPasswordViewModel
    {
        [Display(Name = "E-Adresa")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

    }

    [Table("Registracija")]
    public class RegisterViewModel
    {

        [Key]
        [Display(Name = "ID Registracije")]
        public int RegisterID { get; set; }

        [Required]
        [Display(Name = "Ime i prezime")]
        public string Ime_I_Prezime { get; set; }

        [Required]
        [Display(Name = "E-Adresa")]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Lozinka")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Ponovite lozinku")]
        [Compare("Password", ErrorMessage = "Prva lozinka i ponovljena lozinka se NE poklapaju.")]
        public string ConfirmPassword { get; set; }

    }
}