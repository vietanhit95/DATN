using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADS.APP.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult DashBoard()
        {
            if (Session["AdminLogin"] == null)
            {
                return RedirectToAction("Login", "User", new { Areas = "Admin" });
            }
            else
            {
                return View();
            }
        }
    }
}