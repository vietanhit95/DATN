using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADS.APP.Models;

namespace ADS.APP.Areas.Admin.Controllers
{
    public class CustommerController : Controller
    {
        // GET: Admin/Custommer
        ADS_Entities db = new ADS_Entities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListCustomer(string keyseach = "")
        {
            CustommerViewModels model = new CustommerViewModels();
            model.lstCustommer = db.Custommers.Where(n => n.FullName.Contains(keyseach)).ToList();
            model.lstProvince = db.Provinces.ToList();
            return PartialView(model);
        }
        public ActionResult Add()
        {
            return PartialView();
        }
        [HttpPost]
        public JsonResult DeleteCus(int id)
        {
            var free = db.Custommers.ToList().Find(n => n.Id == id);

            if (free != null)
            {
                db.Custommers.Remove(free);
                db.SaveChanges();
            }
            List<Article> Fre = db.Articles.ToList();
            return Json(Fre, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult SeachCustommer(string keyseach)
        {
            var Cus = db.Custommers.Where(n => n.FullName.Contains(keyseach)).Select(a => new
            {
                id = a.Id,
                fullname = a.FullName,
                address = a.Address,
                username = a.UserName,
                pass = a.PassWord,
                status = a.Status
            }).ToList();
            return Json(Cus, JsonRequestBehavior.AllowGet);
        }



    }
}