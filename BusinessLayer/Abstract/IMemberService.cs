using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMemberService
    {
        List<Member> GetList();
        void MemberAdd(Member member);
        void MemberDelete(Member member);
        void MemberUpdate(Member member);
        Member GetByID(int id);
    }
}
