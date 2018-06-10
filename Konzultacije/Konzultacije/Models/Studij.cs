using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Konzultacije.Models
{
    [Table("Studij")]
    public class Studij
    {
        public int Id_studij { get; set; }
        public string Naziv { get; set; }

    }
}