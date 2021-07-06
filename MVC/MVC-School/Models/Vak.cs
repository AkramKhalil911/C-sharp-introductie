using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_School.Models
{
    public class Vak
    {
        public Vak()
        {
            VakStudenten = new HashSet<VakStudent>();
        }
        public int Id { get; set; }

        [StringLength(20)]
        public string Naam { get; set; }
        [ForeignKey("Docent"), Display(Name = "Docent")]
        public int DocentId { get; set; }
        public virtual Docent Docent { get; set; }
        public ICollection<VakStudent> VakStudenten { get; set; }
    }
}
