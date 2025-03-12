using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class Member
    {
        [Key]
        public int MemberID { get; set; }

        [StringLength(50)]
        public string MemberName { get; set; }

        [StringLength(50)]
        public string MemberSurname { get; set; }

        [StringLength(20)]
        public string MemberPhone { get; set; }

        [StringLength(100)]
        public string MemberMail { get; set; }

        public int MemberTitleID { get; set; }
        public virtual MemberTitle MemberTitle { get; set; }

        [StringLength(50)]
        public string MemberPassword { get; set; }

        [StringLength(1)]
        public string MemberGender { get; set; }// e-k ,erkek-kadın


        public DateTime MemberBirthDate { get; set; }
        public bool MemberStatus { get; set; }

        public ICollection<Team> Teams { get; set; }
        public ICollection<Customer> Customers { get; set; }
        public ICollection<Session> Sessions { get; set; }

    }
}
