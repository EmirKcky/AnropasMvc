using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concreate;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate
{
    public class MemberManager : IMemberService
    {
        IMemberDal _memberDal;

        public MemberManager(IMemberDal memberDal)
        {
            _memberDal = memberDal;
        }

        public Member GetByID(int id)
        {
            return _memberDal.Get(x => x.MemberID == id);
        }

        public List<Member> GetList()
        {
            return _memberDal.List();
        }

        public void MemberAdd(Member member)
        {
            _memberDal.Add(member);
        }

        public void MemberDelete(Member member)
        {
            _memberDal.Delete(member);
        }

        public void MemberUpdate(Member member)
        {
            _memberDal.Update(member);
        }
    }
}
