using ADS.APP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADS.APP.Areas.Admin.Controllers
{
    public class StaffController : Controller
    {
        ADS_Entities db = new ADS_Entities();
        // GET: Admin/Staff
        public ActionResult Index()
        {
            if (Session["AdminLogin"] == null)
            {
                return RedirectToAction("Login", "AdminUser", new { Areas = "Admin" });
            }
            else
            {
                List<Staff> lstCategory = db.Staffs.ToList();
                return View(lstCategory);
            }
        }
    }
}