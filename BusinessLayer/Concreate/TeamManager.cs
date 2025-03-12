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
    public class TeamManager : ITeamService
    {
        ITeamDal _teamDal;

        public TeamManager(ITeamDal teamDal)
        {
            _teamDal = teamDal;
        }

        public Team GetByID(int id)
        {
            return _teamDal.Get(x => x.TeamID == id);
        }

        public List<Team> GetList()
        {
            return _teamDal.List();
        }

        public List<Team> GetListByMember(int id)
        {
            return _teamDal.List(x => x.MemberID == id);
        }

        public void TeamAdd(Team team)
        {
            _teamDal.Add(team);
        }

        public void TeamDelete(Team team)
        {
            _teamDal.Delete(team);
        }

        public void TeamUpdate(Team team)
        {
            _teamDal.Update(team);
        }
    }
}
