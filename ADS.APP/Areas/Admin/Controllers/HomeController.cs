using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADS.APP.Models;

namespace ADS.APP.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        ADS_Entities db = new ADS_Entities();
        // GET: Admin/Home
        public ActionResult DashBoard()
        {
            if (Session["AdminLogin"] == null)
            {
                return RedirectToAction("Login", "AdminUser", new { Areas = "Admin" });
            }
            else
            {
                return View();
            }
        }

        public JsonResult TongHopBaiViet()
        {
            JsonResult jResult = new JsonResult();

            var Result = (from b in db.Articles
                          join c in db.Categories on b.CategoryId equals c.Id
                          group c by new { b.CategoryId, c.Name } into g
                          select new
                          {
                                Id = g.Key.CategoryId,
                                Name = g.Key.Name,
                                Total = g.Count()
                          }).ToList();

            jResult = Json(new { data = Result }, JsonRequestBehavior.AllowGet);
            return jResult;

        }
    }
}