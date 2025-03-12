using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class Firm
    {
        [Key]
        public int FirmID { get; set; }

        [StringLength(100)]
        public string FirmName { get; set; }

        [StringLength(100)]
        public string FirmMail { get; set; }

        [StringLength(20)]
        public string FirmPhone { get; set; }

        [StringLength(50)]
        public string FirmCode { get; set; }

        [StringLength(1)]
        public string FirmPackage { get; set; }//a-b-c paketleri

        [StringLength(200)]
        public string FirmImage { get; set; }

        [StringLength(500)]
        public string FirmAbout { get; set; }

        public DateTime FirmBirthDate { get; set; }

        public bool FirmStatus { get; set; }

        public ICollection<Team> Teams { get; set; }
        public ICollection<Customer> Customers { get; set; }
        public ICollection<Session> Sessions { get; set; }
    }
}
