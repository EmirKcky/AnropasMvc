using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class MemberTitle
    {
        [Key]
        public int MemberTitleID { get; set; }

        [Required]
        [StringLength(50)]
        public string MemberTitleName { get; set; }

        public ICollection<Member> Members { get; set; }
    }
}
