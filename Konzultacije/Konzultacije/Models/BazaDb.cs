using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Konzultacije.Models
{
    public class BazaDb
    {
        // liste
        private static List<Student> studenti = new List<Student>();
        private static List<Profesor> profesori = new List<Profesor>();
        private static List<Upit> upiti = new List<Upit>();
        private static List<Termini> termini = new List<Termini>();

        // STUDENTI
        // Azuriranje
        public void AzuriranjeStudenta(Student s)
        {
            int index = studenti.FindIndex(x => x.StudentID == s.StudentID);
            studenti[index] = s;

        }

        // Upis
        public void UpisStudenta(Student s)
        {
            int noviId = studenti.Max(x => x.StudentID) + 1;
            s.StudentID = noviId;
            studenti.Add(s);
        }

        //Brisanje
        public void ObrisiStudenta(Student s)
        {
            int index = studenti.FindIndex(x => x.StudentID == s.StudentID);
            studenti.RemoveAt(index);
        }

        public List<Student> VratiStudente()
        {
            return studenti;
        }



    }
}