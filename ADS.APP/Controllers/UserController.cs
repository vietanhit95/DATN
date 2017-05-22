using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADS.APP.Models;
using System.Web.Security;

namespace ADS.APP.Controllers
{
    public class UserController : Controller
    {
        ADS_Entities db = new ADS_Entities();
        // GET: User
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Custommer Cus)
        {
            var cus = db.Custommers.SingleOrDefault(n => n.UserName == Cus.UserName);
            if (cus != null)
            {
                if (cus.PassWord == Cus.PassWord)
                {
                    Session["Login"] = cus;
                    return RedirectToAction("Home", "Page");
                }
            }
            return View();
        }
        public ActionResult SingUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CustommerCreate(FormCollection form)
        {
            Custommer cus = new Custommer();
            cus.FullName = form["fullname"].ToString();
            cus.UserName = form["username"].ToString();
            cus.PassWord = form["pass"].ToString();
            cus.PhoneNumber = int.Parse(form["phone"].ToString());
            cus.Email = form["email"].ToString();
            List<Custommer> lstCus = db.Custommers.Where(n => n.UserName == cus.UserName).ToList();
            if (lstCus.Count == 0)
            {
                db.Custommers.Add(cus);
                db.SaveChanges();
            }
            else
            {
                return View();
            }
            return RedirectToAction("Login", "User");
        }
        public ActionResult Profilee()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["Login"] = null;
            return RedirectToAction("Home", "Page");

        }

    }
}