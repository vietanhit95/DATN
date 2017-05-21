using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADS.APP.Models;
using System.IO;

namespace ADS.APP.Controllers
{
    public class ArticleController : Controller
    {
        ADS_Entities db = new ADS_Entities();
        // GET: Article
        public ActionResult ArticleCreate()
        {
            List<Category> oCategory = db.Categories.Where(n => n.CategoryId == 1).ToList();
            List<SelectListItem> lstDrop = new List<SelectListItem>();
            lstDrop.Add(new SelectListItem
            {
                Value = "",
                Text = "Danh mục đăng bài"
            });
            foreach (var list in oCategory)
            {
                lstDrop.Add(new SelectListItem
                {
                    Text = list.Name,
                    Value = list.Id.ToString()
                });
            }
            ViewBag.lstDop = lstDrop;
            return View();
        }
        [HttpPost]
        public ActionResult ArticleFreeAdd(ArticleViewModel Free_Article, IEnumerable<HttpPostedFileBase> fileselect, FormCollection form)
        {
            Category cate = new Category();
            string path = "";
            Free_Article free = new Models.Free_Article();
            Custommer Cus = new Custommer();
            Image img = new Image();
            try
            {
                if (Free_Article.Article != null)
                {
                    free.Decreption = Free_Article.Article.Decreption;
                    free.Title = Free_Article.Article.Title;
                    free.Status = "W";
                    free.Price = Free_Article.Article.Price;
                    free.CreateDate = DateTime.Now;
                    db.Free_Article.Add(free);
                    db.SaveChanges();
                    if (fileselect != null)
                    {
                        foreach (var file in fileselect)
                        {
                            if (file.ContentLength > 0)
                            {
                                if (Path.GetExtension(file.FileName).ToLower() == ".jpg" || Path.GetExtension(file.FileName).ToLower() == ".png" || Path.GetExtension(file.FileName).ToLower() == ".jpeg")
                                {
                                    string name = file.FileName.ToString() + "_" + DateTime.Now.Date.ToString("dd") + "_" + DateTime.Now.Month.ToString("MM") + "_" + DateTime.Now.Year + "_" + DateTime.Now.Hour.ToString() + "_" + DateTime.Now.Minute.ToString() + "_" + DateTime.Now.Second.ToString() + "_" + DateTime.Now.Ticks.ToString();
                                    path = Path.Combine(Server.MapPath("~/Image/User"), name);
                                    file.SaveAs(path);
                                    img.Name = name;
                                    img.ImageId = free.Id;
                                    db.Images.Add(img);
                                    db.SaveChanges();
                                }
                            }
                        }
                    }
                    if (Free_Article.Cus != null)
                    {
                        Cus.ArticleId = free.Id;
                        Cus.PhoneNumber = Free_Article.Cus.PhoneNumber;
                        Cus.FullName = Free_Article.Cus.FullName;
                        Cus.Email = Free_Article.Cus.Email;
                        db.Custommers.Add(Cus);
                        db.SaveChanges();
                    }
                    cate.ArticleId = free.Id;
                    cate.Name = form["select"].ToString();
                    cate.Status = "Y";
                    cate.CategoryId = 1;
                    db.Categories.Add(cate);
                    db.SaveChanges();


                }
            }
            catch (Exception ex)
            {
                return View();
            }



            return RedirectToAction("PageSuccess", "Article");
        }
        public ActionResult ListProduct()
        {
            return View();
        }
        public ActionResult Detail()
        {
            return View();

        }
        public ActionResult PageSuccess()
        {
            return View();
        }
        public ActionResult PageError()
        {
            return View();
        }
    }
}