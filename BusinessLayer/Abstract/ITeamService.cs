using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ITeamService
    {
        List<Team> GetList();
        List<Team> GetListByMember(int id);
        void TeamAdd(Team team);
        void TeamDelete(Team team);
        void TeamUpdate(Team team);
        Team GetByID(int id);
    }
}
