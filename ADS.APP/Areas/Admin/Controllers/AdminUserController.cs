using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADS.APP.Models;

namespace ADS.APP.Areas.Admin.Controllers
{
    public class AdminUserController : Controller
    {
        ADS_Entities db = new ADS_Entities();
        // GET: Admin/User
        public ActionResult Login()
        {
            Session["AdminLogin"] = "";
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            string user = form["username"].ToString();
            string pass = form["password"].ToString();
            var staff = db.Staffs.SingleOrDefault(n => n.UserName == user);
            if (staff != null)
            {
                if (staff.PassWord == pass)
                {
                    Session["AdminLogin"] = staff;
                    return RedirectToAction("DashBoard", "Home", new { Areas = "Admin" });
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult SingUp(FormCollection form)
        {
            string fullname = form["fullname"].ToString();
            string user = form["username"].ToString();
            string pass = form["password"].ToString();
            string address = form["address"].ToString();
            Staff sta = new Staff();
            var staff = db.Staffs.SingleOrDefault(n => n.UserName == user);
            if (staff != null)
            {
                return View();
            }
            else
            {
                sta.FullName = fullname;
                sta.UserName = user;
                sta.Address = address;
                sta.PassWord = pass;
                sta.Status = "Y";
                sta.StaffType = "Y";
                db.Staffs.Add(sta);
                db.SaveChanges();
                return RedirectToAction("Login", "User", new { Areas = "Admin" });
            }

        }
    }
}