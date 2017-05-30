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
        public ActionResult ArticleFreeAdd(ArticleViewModel Free_Article, IEnumerable<HttpPostedFileBase> fileselect)
        {
            Category cate = new Category();
            string path = "";
            Article free = new Models.Article();
            Custommer Cus = new Custommer();
            Image img = new Image();
            try
            {
                if (Free_Article.AdvandeArticle != null)
                {
                    free.Article_Content = Free_Article.AdvandeArticle.Article_Content;
                    free.Article_Title = Free_Article.AdvandeArticle.Article_Title;
                    free.Status = "W";
                    free.Article_Price = Free_Article.AdvandeArticle.Article_Price;
                    free.Article_Type = 0;
                    free.Created_Date = DateTime.Now;
                    free.Article_CategoryId = Free_Article.AdvandeArticle.Article_CategoryId;
                    db.Articles.Add(free);
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

                }
            }
            catch (Exception ex)
            {
                return View();
            }



            return RedirectToAction("PageSuccess", "Article");
        }
        public ActionResult AdvandArticleCreate()
        {
            if (Session["Login"] != null)
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
            else
            {
                return RedirectToAction("Login", "User");
            }
        }
        [HttpPost]
        public ActionResult AdvandArticleCreateAdd(ArticleViewModel Article, IEnumerable<HttpPostedFileBase> fileselect, FormCollection form)
        {
            Card card = new Card();
            Category cate = new Category();
            string path = "";
            Article Art = new Models.Article();
            Custommer Cus = new Custommer();
            Image img = new Image();
            try
            {
                if (Article.AdvandeArticle != null)
                {
                    Art.Article_Content = Article.AdvandeArticle.Article_Content;
                    Art.Article_Title = Article.AdvandeArticle.Article_Title;
                    Art.Created_Date = DateTime.Now;
                    Art.CardId = int.Parse(form["TypeCard"].ToString());
                    db.Articles.Add(Art);
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
                                    img.ImageId = Art.Id;
                                    db.Images.Add(img);
                                    db.SaveChanges();
                                }
                            }
                        }
                    }
                    Cus.ArticleId = Art.Id;
                    Cus.PhoneNumber = int.Parse(form["phone"].ToString());
                    Cus.FullName = form["fullname"].ToString();
                    Cus.Email = form["addressemail"].ToString();
                    db.Custommers.Add(Cus);
                    db.SaveChanges();
                    string text = "";
                    string type = "";
                    type = form["TypeCard"].ToString();
                    if (type == "1")
                    {
                        text = "Viettel";
                    }
                    else if (type == "2")
                    {
                        text = "Vina Phone";
                    }
                    else if (type == "3")
                    {
                        text = "Mobi Phone";
                    }
                    card.Type = text;
                    card.CustommerId = Cus.Id;
                    db.Cards.Add(card);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return View();
            }

            return RedirectToAction("PageSuccess", "Article");
        }
        public ActionResult Mobie()
        {
            ListViewArticle model = new ListViewArticle();
            model.lstArticle = db.Articles.Where(n=>n.Article_CategoryId == 1).ToList();
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