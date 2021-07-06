using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MVC_School.Models
{
    public class Student
    {
        public Student()
        {
            StudentVakken = new HashSet<VakStudent>();
        }
        public int ID { get; set; }
        [StringLength(20)]
        public string Voornaam { get; set; }
        [StringLength(40)]
        public string Achternaam { get; set; }
        [StringLength(40)]
        public string Adres { get; set; }
        [StringLength(40)]
        public string Woonplaats { get; set; }
        public ICollection<VakStudent> StudentVakken { get; set; }
    }
}
