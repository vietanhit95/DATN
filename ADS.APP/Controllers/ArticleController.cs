using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADS.APP.Models;
using System.IO;
using System.Globalization;

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
        public ActionResult ArticleAdd()
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
        public ActionResult ArticleAdd(ArticleViewModel Free_Article, IEnumerable<HttpPostedFileBase> fileselect, FormCollection form)
        {
            Category cate = new Category();
            string path = "";
            Article free = new Models.Article();
            Custommer Cus = new Custommer();
            Image img = new Image();
            string FullName = form["fullname"].ToString();
            string SDT = form["phone"].ToString();
            string Mail = form["addressemail"].ToString();


            if (Free_Article.AdvandeArticle != null)
            {
                free.Decreption = Free_Article.AdvandeArticle.Decreption;
                free.Title = Free_Article.AdvandeArticle.Title;
                free.Status = "W";
                free.ProvinceId = int.Parse(form["Province"].ToString());
                free.DistrictId = int.Parse(form["District"].ToString());

                free.PhoneNumber = int.Parse(SDT.ToString());
                free.UserNameFree = FullName;
                free.EmailFree = Mail;


                free.Price = Free_Article.AdvandeArticle.Price;
                free.Article_Type = "N";
                free.Create_Date = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                free.CategoryId = Free_Article.AdvandeArticle.CategoryId;
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
                                string name = DateTime.Now.Date.ToString("dd") + "_" + DateTime.Now.Month.ToString("MM") + "_" + DateTime.Now.Year + "_" + DateTime.Now.Hour.ToString() + "_" + DateTime.Now.Minute.ToString() + "_" + DateTime.Now.Second.ToString() + "_" + DateTime.Now.Ticks.ToString() + "_" + file.FileName.ToString();
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
            }
            return RedirectToAction("PageSuccess", "Article");
        }
        [HttpPost]
        public ActionResult ArticleFreeAdd(ArticleViewModel Free_Article, IEnumerable<HttpPostedFileBase> fileselect, FormCollection form)
        {
            Category cate = new Category();
            string path = "";
            Article free = new Models.Article();
            Custommer Cus = new Custommer();
            Image img = new Image();



            if (Free_Article.AdvandeArticle != null)
            {
                free.Decreption = Free_Article.AdvandeArticle.Decreption;
                free.Title = Free_Article.AdvandeArticle.Title;
                free.Status = "W";
                free.ProvinceId = int.Parse(form["Province"].ToString());
                free.DistrictId = int.Parse(form["District"].ToString());

                free.PhoneNumber = Free_Article.Cus.PhoneNumber;
                free.UserNameFree = Free_Article.Cus.FullName;
                free.EmailFree = Free_Article.Cus.Email;


                free.Price = Free_Article.AdvandeArticle.Price;
                free.Article_Type = "N";
                free.Create_Date = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                free.CategoryId = Free_Article.AdvandeArticle.CategoryId;
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
                                string name = DateTime.Now.Date.ToString("dd") + "_" + DateTime.Now.Month.ToString("MM") + "_" + DateTime.Now.Year + "_" + DateTime.Now.Hour.ToString() + "_" + DateTime.Now.Minute.ToString() + "_" + DateTime.Now.Second.ToString() + "_" + DateTime.Now.Ticks.ToString() + "_" + file.FileName.ToString();
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
                    Cus.ArticleId = Art.Id;
                    Cus.PhoneNumber = int.Parse(form["phone"].ToString());
                    Cus.FullName = form["fullname"].ToString();
                    Cus.Email = form["addressemail"].ToString();
                    db.Custommers.Add(Cus);
                    db.SaveChanges();


                    Art.Decreption = Article.AdvandeArticle.Decreption;
                    Art.Title = Article.AdvandeArticle.Title;
                    Art.Create_Date = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                    Art.CardId = int.Parse(form["TypeCard"].ToString());
                    Art.CustommerId = Cus.Id;
                    Art.Status = "W";
                    Art.Price = Article.AdvandeArticle.Price;
                    Art.Article_Type = "Y";
                    Art.ProvinceId = int.Parse(form["Province"].ToString());
                    Art.DistrictId = int.Parse(form["District"].ToString());
                    Art.CategoryId = Article.AdvandeArticle.CategoryId;
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
                                    string name = DateTime.Now.Date.ToString("dd") + "_" + DateTime.Now.Month.ToString("MM") + "_" + DateTime.Now.Year + "_" + DateTime.Now.Hour.ToString() + "_" + DateTime.Now.Minute.ToString() + "_" + DateTime.Now.Second.ToString() + "_" + DateTime.Now.Ticks.ToString() + "_" + file.FileName.ToString();
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
                    card.Price = double.Parse(form["CardPrice"].ToString());
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
        [HttpPost]
        public ActionResult Mobie(FormCollection form)
        {
            if (form.Count > 0)
            {
                string method = form["select"].ToString();
                if (method == null && method == "111")
                {
                    List<Article> lstArticle = db.Articles.Where(n => n.CategoryId == 1).ToList();
                    return View(lstArticle);

                }
                else if (method == "333")
                {
                    List<Article> lstArticle = db.Articles.OrderByDescending(n => n.Price).Where(n => n.CategoryId == 1).ToList();
                    return View(lstArticle);

                }
                else if (method == "222")
                {
                    List<Article> lstArticle = db.Articles.OrderBy(n => n.Price).Where(n => n.CategoryId == 1).ToList();
                    return View(lstArticle);

                }
            }
            return View();
        }
        public ActionResult Mobie()
        {

            return View(db.Articles.Where(n => n.CategoryId == 1).ToList());
        }
        public ActionResult Detail(int Id)
        {
            Article Arti = db.Articles.SingleOrDefault(n => n.Id == Id);
            return View(Arti);

        }
        public ActionResult PageSuccess()
        {
            return View();
        }
        public ActionResult PageError()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Seach(string keyseach, FormCollection form)
        {
            int ProvinceId = int.Parse(form["Province"].ToString());
            int CategoryId = int.Parse(form["Menu"].ToString());
            List<Article> Article = db.Articles.Where(n => n.Title.Contains(keyseach) && n.ProvinceId == ProvinceId && n.CategoryId == CategoryId).ToList();
            return View(Article);
        }

    }
}