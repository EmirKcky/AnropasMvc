using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnropasMvc.Controllers
{
    public class SessionController : Controller
    {
        
        public ActionResult AdminSessionIndex()
        {
            return View();
        }

        public ActionResult MemberSessionIndex()
        {
            return View();
        }
    }
}