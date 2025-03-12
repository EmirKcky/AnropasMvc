using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }

        [StringLength(50)]
        public string PaymentName { get; set; }

        public ICollection<Session> Sessions { get; set; }
    }
}
