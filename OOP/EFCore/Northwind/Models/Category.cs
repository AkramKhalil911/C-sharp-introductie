using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Models
{
    public class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        public int CategoryID { get; set; }
        [Required, StringLength(15)]
        public string CategoryName { get; set; }
        [Column(TypeName = "nText")]
        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
