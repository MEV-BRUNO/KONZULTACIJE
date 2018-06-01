using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Konzultacije.Models
{
    public class Termini
    {
        public int Id_profesor { get; set; }
        public int Id_kolegij { get; set; }
        public DateTime Dan_Tjedan { get; set; }
        public DateTime Vrijeme_Od { get; set; }
        public DateTime Vrijeme_Do { get; set; }

    }
}