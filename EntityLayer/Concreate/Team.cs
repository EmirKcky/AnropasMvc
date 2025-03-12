using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class Team
    {
        [Key]
        public int TeamID { get; set; }

        public int FirmID { get; set; }
        public virtual Firm Firm { get; set; }

        public int MemberID { get; set; }
        public virtual Member Member { get; set; }


        [StringLength(1)]
        public string MemberRole { get; set; }//k-p-s, kurucu-psikolog-stajyer
    }
}
