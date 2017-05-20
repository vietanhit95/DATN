using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADS.APP.Models;

namespace ADS.APP.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        ADS_Entities db = new ADS_Entities();
        // GET: Admin/Category
        public ActionResult Index()
        {
            List<Category> lstCategory = db.Categories.ToList();
            return View(lstCategory);
        }
        public ActionResult Add()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult CategoryCreate(Category cate)
        {
            Category _cate = new Category();
            _cate.Name = cate.Name;
            _cate.Status = "Y";
            _cate.CategoryId = cate.CategoryId;
            db.Categories.Add(_cate);
            db.SaveChanges();
            return RedirectToAction("Index", "Category", new { Areas = "Admin" });
        }
    }
}