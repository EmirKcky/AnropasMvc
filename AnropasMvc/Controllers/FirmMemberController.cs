using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnropasMvc.Controllers
{
    public class FirmMemberController : Controller
    {
        FirmManager fm = new FirmManager(new EfFirmDal());

        public ActionResult Index()
        {
            int p = (int)Session["FirmID"];
            var firmvalue = fm.GetByID(p);
            return View(firmvalue);
        }
    }
}