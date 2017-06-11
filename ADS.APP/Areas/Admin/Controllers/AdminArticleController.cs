using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADS.APP.Models;
using PagedList;
using PagedList.Mvc;

namespace ADS.APP.Areas.Admin.Controllers
{
    public class AdminArticleController : Controller
    {
        ADS_Entities db = new ADS_Entities();
        // GET: Admin/Article
        public ActionResult Index(int ? page)
        {
            if (Session["AdminLogin"] == null)
            {
                return RedirectToAction("Login", "AdminUser", new { Areas = "Admin" });
            }
            else
            {
                List<Image> img = new List<Image>();
                var free = (from a in db.Articles
                                       where a.Status == "W"
                                       orderby a.Id descending
                                       select new _Article
                                       {
                                           Id = a.Id,
                                           Decreption = a.Decreption,
                                           Title = a.Title,
                                           ProvinceId = a.ProvinceId,
                                           Article_Type = a.Article_Type,
                                           Price = a.Price,
                                           PhoneNumber = a.PhoneNumber,
                                           Create_Date = a.Create_Date,
                                           Status = a.Status,
                                           CategoryId = a.CategoryId,
                                           CardId = a.CardId,
                                           UserNameFree = a.UserNameFree,
                                           EmailFree = a.EmailFree,
                                           CommentId = a.CommentId,
                                           CustommerId = a.CustommerId,
                                           DistrictId = a.DistrictId,
                                           img = db.Images.Where(n => n.ImageId == a.Id).Take(1)
                                       }).ToPagedList(page ?? 1, 20);

                return View(free);
            }

        }
        public ActionResult ViewDetails(int id = 0)
        {
            string status = "";
            Article free = db.Articles.SingleOrDefault(n => n.Id == id);
            _Article _article = new _Article();
            if (free != null)
            {
                _article.Id = free.Id;
                _article.Decreption = free.Decreption;
                _article.Title = free.Title;
                _article.ProvinceId = free.ProvinceId;
                _article.Article_Type = free.Article_Type;
                _article.Price = free.Price;
                _article.PhoneNumber = free.PhoneNumber;
                _article.Create_Date = free.Create_Date;
                if (free.Status == "W")
                {
                    _article.Status = "Đang chờ duyệt";
                }
                else
                {
                    _article.Status = status;
                }
                _article.CategoryId = free.CategoryId;
                _article.CardId = free.CardId;
                _article.UserNameFree = free.UserNameFree;
                _article.EmailFree = free.EmailFree;
                _article.CommentId = free.CommentId;
                _article.CustommerId = free.CustommerId;
                _article.DistrictId = free.DistrictId;
                _article.img = db.Images.Where(n => n.ImageId == free.Id);
                return View(_article);
            }
            return View();
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