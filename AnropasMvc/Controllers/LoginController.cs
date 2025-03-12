using BusinessLayer.Concreate;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AnropasMvc.Controllers
{
    //[AllowAnonymous]
    public class LoginController : Controller
    {
        MemberTitleManager mtm = new MemberTitleManager(new EfMemberTitleDal());
        MemberManager mm = new MemberManager(new EfMemberDal());

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Member p)
        {
            Context c = new Context();
            var memberinfo = c.Members.FirstOrDefault(x => x.MemberMail == p.MemberMail &&
            x.MemberPassword == p.MemberPassword);

            if (memberinfo != null)
            {
                FormsAuthentication.SetAuthCookie(memberinfo.MemberMail, false);
                Session["MemberID"] = memberinfo.MemberID;
                Session["MemberMail"] = memberinfo.MemberMail;

                return RedirectToAction("AfterLogin", "Login");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            List<SelectListItem> valuemembertitle = (from x in mtm.GetList()
                                                     select new SelectListItem
                                                     {
                                                         Text = x.MemberTitleName,
                                                         Value = x.MemberTitleID.ToString()
                                                     }).ToList();
            ViewBag.vlmtm = valuemembertitle;

            return View();
        }

        [HttpPost]
        public ActionResult SignUp(Member p)
        {
            p.MemberStatus = true;
            mm.MemberAdd(p);
            return RedirectToAction("Login");
        }


        [Authorize]
        public ActionResult AfterLogin()
        {
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("HomePage", "Home");
        }
    }
}