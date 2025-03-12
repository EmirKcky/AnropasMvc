using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class Reference
    {
        [Key]
        public int ReferenceID { get; set; }

        [Required]
        [StringLength(50)]
        public string ReferenceName { get; set; }

        public ICollection<Customer> Customers { get; set; }
    }
}
