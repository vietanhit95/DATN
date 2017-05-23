using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADS.APP.Models;

namespace ADS.APP.Areas.Admin.Controllers
{
    public class ArticleController : Controller
    {
        ADS_Entities db = new ADS_Entities();
        // GET: Admin/Article
        public ActionResult Index()
        {
            if (Session["AdminLogin"] == null)
            {
                return RedirectToAction("Login", "User", new { Areas = "Admin" });
            }
            else
            {
                ListArticle model = new ListArticle();
                List<Free_Article> free = db.Free_Article.Where(n => n.Status == "W").ToList();
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
                return RedirectToAction("Login", "User", new { Areas = "Admin" });
            }
            else
            {
                ListArticle model = new ListArticle();
                List<Free_Article> free = db.Free_Article.Where(n => n.Status == "N").ToList();
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
                return RedirectToAction("Login", "User", new { Areas = "Admin" });
            }
            else
            {
                ListArticle model = new ListArticle();
                List<Free_Article> free = db.Free_Article.Where(n => n.Status == "Y").ToList();
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
            var free = db.Free_Article.ToList().Find(n => n.Id == id);

            if (free != null)
            {
                free.Status = "Y";
                db.SaveChanges();
            }
            List<Free_Article> Fre = db.Free_Article.ToList();
            return Json(Fre, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult DeleteArticle(int id)
        {
            var free = db.Free_Article.ToList().Find(n => n.Id == id);

            if (free != null)
            {
                free.Status = "N";
                db.SaveChanges();
            }
            List<Free_Article> Fre = db.Free_Article.ToList();
            return Json(Fre, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult RestoreArticle(int id)
        {
            var free = db.Free_Article.ToList().Find(n => n.Id == id);

            if (free != null)
            {
                free.Status = "Y";
                db.SaveChanges();
            }
            List<Free_Article> Fre = db.Free_Article.ToList();
            return Json(Fre, JsonRequestBehavior.AllowGet);
        }
    }
}