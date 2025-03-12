using BusinessLayer.Concreate;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AnropasMvc.Controllers
{
    public class MemberPanelController : Controller
    {

        FirmManager fm = new FirmManager(new EfFirmDal());
        TeamManager tm = new TeamManager(new EfTeamDal());

        [HttpGet]
        public ActionResult CreateFirm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateFirm(Firm p)
        {
            // Rastgele kod üret ve FirmCode özelliğine ata
            p.FirmCode = GenerateRandomCode();

            p.FirmBirthDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.FirmStatus = true;
            fm.FirmAdd(p);

            Context c = new Context();
            var firmidinfo = c.Firms.FirstOrDefault(x => x.FirmID == p.FirmID);
            if (firmidinfo != null)
            {
                Team t = new Team();
                t.FirmID = firmidinfo.FirmID;
                t.MemberID = (int)Session["MemberID"];
                t.MemberRole = "K";
                tm.TeamAdd(t);
                return RedirectToAction("JoinFirm");
            }
            else
            {
                return RedirectToAction("CreateFirm");
            }
        }

        public string GenerateRandomCode()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"; // Kullanılacak karakterler
            var random = new Random();
            var code = new StringBuilder();

            // Her bir bölüm için rastgele karakterler üret
            for (int i = 0; i < 4; i++)
            {
                code.Append(new string(Enumerable.Repeat(chars, 4)
                    .Select(s => s[random.Next(s.Length)]).ToArray()));
                if (i < 3) code.Append('-'); // Bölümler arasına tire ekle
            }

            // Son iki bölüm için 2 karakter üret
            code.Append('-');
            code.Append(new string(Enumerable.Repeat(chars, 2)
                .Select(s => s[random.Next(s.Length)]).ToArray()));
            code.Append('-');
            code.Append(new string(Enumerable.Repeat(chars, 2)
                .Select(s => s[random.Next(s.Length)]).ToArray()));

            return code.ToString();
        }

        public ActionResult JoinFirm()
        {
            int p = (int)Session["MemberID"];
            var values = tm.GetListByMember(p);
            return View(values);
        }


        [HttpGet]
        public ActionResult NewJoinFirm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewJoinFirm(Firm p)
        {
            Context c = new Context();
            var firmaidinfo = c.Firms.FirstOrDefault(x => x.FirmCode == p.FirmCode &&
            x.FirmName == p.FirmName);

            if (firmaidinfo != null)
            {
                Team t = new Team();
                t.FirmID = firmaidinfo.FirmID;
                t.MemberID = (int)Session["MemberID"];
                t.MemberRole = "P";
                tm.TeamAdd(t);
                return RedirectToAction("JoinFirm");
            }
            else
            {
                return RedirectToAction("AfterLogin", "Login");
            }
        }


        public ActionResult SetFirmSession(int? firmID)
        {
            if (!firmID.HasValue)
            {
                return RedirectToAction("AfterLogin", "Login"); // Hata durumunda yönlendirme
            }

            // FirmID'yi Session'a ata
            Session["FirmID"] = firmID.Value;

            // Kullanıcının rolüne göre yönlendirme yap
            var memberRole = GetMemberRole(firmID.Value);
            if (memberRole == "K")
            {
                return RedirectToAction("Index", "FirmAdmin");
            }
            else if (memberRole == "P")
            {
                return RedirectToAction("Index", "FirmMember");
            }
            else
            {
                return RedirectToAction("JoinFirm", "MemberPanel"); // Hata durumunda yönlendirme
            }
        }

        private string GetMemberRole(int firmID)
        {
            // Bu metot, kullanıcının firma içindeki rolünü döndürür
            Context c = new Context();
            var memberID = (int)Session["MemberID"];
            var teamMember = c.Teams.FirstOrDefault(t => t.FirmID == firmID && t.MemberID == memberID);
            return teamMember?.MemberRole;
        }
    }
}