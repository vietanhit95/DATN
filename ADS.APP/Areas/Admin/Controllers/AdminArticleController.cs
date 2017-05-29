using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADS.APP.Models;

namespace ADS.APP.Areas.Admin.Controllers
{
    public class AdminArticleController : Controller
    {
        ADS_Entities db = new ADS_Entities();
        // GET: Admin/Article
        public ActionResult Index()
        {
            if (Session["AdminLogin"] == null)
            {
                return RedirectToAction("Login", "AdminUser", new { Areas = "Admin" });
            }
            else
            {
                ListArticle model = new ListArticle();
                List<Article> free = db.Articles.Where(n => n.Status == "W").ToList();
                if (free != null)
                {
                    for (int i = 0; i < free.Count; i++)
                    {
                        var item = free[i];
                        model.lstImage = db.Images.Where(n => n.ImageId == item.Id).ToList();
                    }
                }
                model.lstFree = free;

                return View(model);
            }

        }
        public ActionResult ArticleSave()
        {
            if (Session["AdminLogin"] == null)
            {
                return RedirectToAction("Login", "AdminUser", new { Areas = "Admin" });
            }
            else
            {
                ListArticle model = new ListArticle();
                List<Article> free = db.Articles.Where(n => n.Status == "N").ToList();
                if (free != null)
                {
                    for (int i = 0; i < free.Count; i++)
                    {
                        var item = free[i];
                        model.lstImage = db.Images.Where(n => n.ImageId == item.Id).ToList();
                    }
                }
                model.lstFree = free;

                return View(model);
            }
        }
        public ActionResult SuccessArticle()
        {
            if (Session["AdminLogin"] == null)
            {
                return RedirectToAction("Login", "AdminUser", new { Areas = "Admin" });
            }
            else
            {
                ListArticle model = new ListArticle();
                List<Article> free = db.Articles.Where(n => n.Status == "Y").ToList();
                if (free != null)
                {
                    for (int i = 0; i < free.Count; i++)
                    {
                        var item = free[i];
                        model.lstImage = db.Images.Where(n => n.ImageId == item.Id).ToList();
                    }
                }
                model.lstFree = free;

                return View(model);
            }
        }
        [HttpPost]
        public JsonResult ConfirmArticle(int id)
        {
            var free = db.Articles.ToList().Find(n => n.Id == id);

            if (free != null)
            {
                free.Status = "Y";
                db.SaveChanges();
            }
            List<Article> Fre = db.Articles.ToList();
            return Json(Fre, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult DeleteArticle(int id)
        {
            var free = db.Articles.ToList().Find(n => n.Id == id);

            if (free != null)
            {
                free.Status = "N";
                db.SaveChanges();
            }
            List<Article> Fre = db.Articles.ToList();
            return Json(Fre, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult RestoreArticle(int id)
        {
            var free = db.Articles.ToList().Find(n => n.Id == id);

            if (free != null)
            {
                free.Status = "Y";
                db.SaveChanges();
            }
            List<Article> Fre = db.Articles.ToList();
            return Json(Fre, JsonRequestBehavior.AllowGet);
        }
    }
}