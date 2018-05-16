using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Konzultacije.Models
{
    public class Profesor
    {
       public int Id_profesor { get; set; }
       public string Ime_I_Prezime { get; set; }
       public string Email { get; set; }
       public string Lozinka { get; set; }
       public string Aktivacijski_Link { get; set; }
       public bool Aktivan { get; set; }

    }
}