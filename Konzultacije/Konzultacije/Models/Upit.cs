using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Konzultacije.Models
{
    public class Upit
    {
        public int Id_upit { get; set; }
        public int Id_student { get; set; }
        public int Id_profesor { get; set; }
        public DateTime Datum { get; set; }
        public string Naslov { get; set; }
        public string Opis { get; set; }
        public bool Odgovoren { get; set; }

    }
}