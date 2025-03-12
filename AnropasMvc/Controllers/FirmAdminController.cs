using Antlr.Runtime.Tree;
using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace AnropasMvc.Controllers
{
    public class FirmAdminController : Controller
    {
        FirmManager fm = new FirmManager(new EfFirmDal());

        public ActionResult Index()
        {
            int p = (int)Session["FirmID"];
            var firmvalue = fm.GetByID(p);
            return View(firmvalue);
        }

        public ActionResult FirmCode()
        {
            int p = (int)Session["FirmID"];
            var firmvalue = fm.GetByID(p);
            return View(firmvalue);
        }

        public ActionResult FirmProfile()
        {
            int p = (int)Session["FirmID"];
            var firmvalue = fm.GetByID(p);
            return View(firmvalue);
        }

        public ActionResult MemberProfile()
        {
            return View();
        }
    }
}