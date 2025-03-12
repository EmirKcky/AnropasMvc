using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class Session
    {
        [Key]
        public int SessionID { get; set; }

        public int? MemberID { get; set; }
        public virtual Member Member { get; set; }

        public int? FirmID { get; set; }
        public virtual Firm Firm { get; set; }

        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }

        [StringLength(1)]
        public string CustomerType { get; set; }// k-f, kendinin firmanın

        public int PaymentID { get; set; }
        public virtual Payment Payment { get; set; }

        public DateTime SessionDateTime { get; set; }

        [Required]
        public int SessionPaymentReceived { get; set; }

        [Required]
        public int SessionPaymentRemaining { get; set; }

        [StringLength(500)]
        public string SessionDescription { get; set; }
    }
}
