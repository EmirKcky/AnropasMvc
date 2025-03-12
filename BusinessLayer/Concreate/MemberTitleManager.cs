using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate
{
    public class MemberTitleManager: IMemberTitleService
    {
        IMemberTitleDal _membertitleDal;

        public MemberTitleManager(IMemberTitleDal membertitleDal)
        {
            _membertitleDal = membertitleDal;
        }

        public MemberTitle GetByID(int id)
        {
            return _membertitleDal.Get(x => x.MemberTitleID == id);
        }

        public List<MemberTitle> GetList()
        {
            return _membertitleDal.List();
        }

        public void MemberTitleAdd(MemberTitle membertitle)
        {
            _membertitleDal.Add(membertitle);
        }

        public void MemberTitleDelete(MemberTitle membertitle)
        {
            _membertitleDal.Delete(membertitle);
        }

        public void MemberTitleUpdate(MemberTitle membertitle)
        {
            _membertitleDal.Update(membertitle);
        }
    }
}
