using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        [StringLength(50)]
        public string CustomerName { get; set; }

        [StringLength(50)]
        public string CustomerSurname { get; set; }

        [StringLength(100)]
        public string CustomerMail { get; set; }

        [StringLength(20)]
        public string CustomerPhone { get; set; }

        [StringLength(1)]
        public string CustomerGender { get; set; }// e-k ,erkek-kadın

        public DateTime CustomerBirthDate { get; set; }

        public int ReferenceID { get; set; }
        public virtual Reference Reference { get; set; }

        public int MemberID { get; set; }
        public virtual Member Member { get; set; }

        public int FirmID { get; set; }
        public virtual Firm Firm { get; set; }

        [StringLength(1)]
        public string CustomerType { get; set; }// k-f, kendinin firmanın

        [StringLength(200)]
        public string CustomerAddress { get; set; }

        [StringLength(1)]
        public string CustomerNationality { get; set; }// t-y, türk yabancı

        public bool CustomerStatus { get; set; }


        public ICollection<Session> Sessions { get; set; }
    }
}
