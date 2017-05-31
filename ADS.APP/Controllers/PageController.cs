using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADS.APP.Models;
namespace ADS.APP.Controllers
{
    public class PageController : Controller
    {
        ADS_Entities db = new ADS_Entities();
        // GET: Page
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult SeachProvince(string q)
        {
            var CityName = db.Provinces.Where(x => x.Name.Contains(q)).Select(a => new
            {
                id = a.Id,
                name = a.Name
            }).ToList();

            return Json(CityName, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SeachProvinceV1()
        {
            var CityName = db.Provinces.Select(a => new
            {
                id = a.Id,
                type = a.Type,
                name = a.Name
            }).ToList();

            return Json(CityName, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SeachDistrict(int ProvinceId)
        {
            var District = db.Districts.Where(x => x.ProvinceId == ProvinceId).Select(a => new
            {
                id = a.Id,
                type = a.Type,
                name = a.Name
            }).ToList();

            return Json(District, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Menu()
        {
            var Category = db.Categories.Select(a => new
            {
                id = a.Id,
                name = a.Name
            }).ToList();

            return Json(Category, JsonRequestBehavior.AllowGet);
        }
    }
}