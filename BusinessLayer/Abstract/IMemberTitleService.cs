using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMemberTitleService
    {
        List<MemberTitle> GetList();
        void MemberTitleAdd(MemberTitle membertitle);
        void MemberTitleDelete(MemberTitle membertitle);
        void MemberTitleUpdate(MemberTitle membertitle);
        MemberTitle GetByID(int id);
    }
}
