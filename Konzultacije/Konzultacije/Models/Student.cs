using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Konzultacije.Models
{
    public class Student
    {

        public int Id_student { get; set; }
        public string Ime_I_Prezime { get; set; }
        public int Id_studij { get; set; }
        public string Email { get; set; }
        public string Lozinka { get; set;}
        public string Aktivacijski_link { get; set; }
        public bool Aktivan { get; set; }

    }
}