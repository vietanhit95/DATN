using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADS.APP.Models;
using System.IO;
using System.Globalization;
using PagedList;
using PagedList.Mvc;

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

                free.PhoneNumber = SDT.ToString();
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
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateAntiForgeryToken]
        public ActionResult ArticleFreeAdd(ArticleViewModel Free_Article, IEnumerable<HttpPostedFileBase> fileselect, FormCollection form)
        {
            Category cate = new Category();
            string path = "";
            Article free = new Models.Article();
            Custommer Cus = new Custommer();
            Image img = new Image();



            if (Free_Article != null)
            {
                free.Decreption = Free_Article.AdvandeArticle.Decreption;
                free.Title = Free_Article.AdvandeArticle.Title;
                free.Status = "W";
                free.ProvinceId = int.Parse(form["Province"].ToString());
                free.DistrictId = int.Parse(form["District"].ToString());

                free.PhoneNumber = Free_Article.Cus.PhoneNumber;
                free.UserNameFree = Free_Article.Cus.FullName;
                free.EmailFree = Free_Article.Cus.EmailUser;


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
        #region Mobie
        [HttpPost]
        public ActionResult Mobie(int? page, FormCollection form)
        {
            if (form.Count > 0)
            {
                string method = form["select"].ToString();
                if (method == "111")
                {
                    var lstArticle = db.Articles.OrderByDescending(n => n.Create_Date).Where(n => n.CategoryId == 1 && n.Status == "Y").ToPagedList(page ?? 1, 8);
                    return View(lstArticle);

                }
                else if (method == "333")
                {
                    var lstArticle = db.Articles.OrderByDescending(n => n.Price).Where(n => n.CategoryId == 1 && n.Status == "Y").ToPagedList(page ?? 1, 8);
                    return View(lstArticle);

                }
                else if (method == "222")
                {
                    var lstArticle = db.Articles.OrderBy(n => n.Price).Where(n => n.CategoryId == 1 && n.Status == "Y").ToPagedList(page ?? 1, 8);
                    return View(lstArticle);

                }
            }
            return View();
        }
        public ActionResult Mobie(int? page)
        {
            return View(db.Articles.OrderBy(n => n.Id).Where(n => n.CategoryId == 1 && n.Status == "Y").ToPagedList(page ?? 1, 8));
        }

        #endregion
        #region Laptop
        [HttpPost]
        public ActionResult Laptop(int? page, FormCollection form)
        {
            if (form.Count > 0)
            {
                string method = form["select"].ToString();
                if (method == "111")
                {
                    var lstArticle = db.Articles.OrderByDescending(n => n.Create_Date).Where(n => n.CategoryId == 2 && n.Status == "Y").ToPagedList(page ?? 1, 8);
                    return View(lstArticle);

                }
                else if (method == "333")
                {
                    var lstArticle = db.Articles.OrderByDescending(n => n.Price).Where(n => n.CategoryId == 2 && n.Status == "Y").ToPagedList(page ?? 1, 8);
                    return View(lstArticle);

                }
                else if (method == "222")
                {
                    var lstArticle = db.Articles.OrderBy(n => n.Price).Where(n => n.CategoryId == 2 && n.Status == "Y").ToPagedList(page ?? 1, 8);
                    return View(lstArticle);

                }
            }
            return View();
        }
        public ActionResult Laptop(int? page)
        {
            return View(db.Articles.OrderBy(n => n.Id).Where(n => n.CategoryId == 2 && n.Status == "Y").ToPagedList(page ?? 1, 8));
        }
        #endregion
        #region PC
        [HttpPost]
        public ActionResult PC(int? page, FormCollection form)
        {
            if (form.Count > 0)
            {
                string method = form["select"].ToString();
                if (method == "111")
                {
                    var lstArticle = db.Articles.OrderByDescending(n => n.Create_Date).Where(n => n.CategoryId == 6 && n.Status == "Y").ToPagedList(page ?? 1, 8);
                    return View(lstArticle);

                }
                else if (method == "333")
                {
                    var lstArticle = db.Articles.OrderByDescending(n => n.Price).Where(n => n.CategoryId == 6 && n.Status == "Y").ToPagedList(page ?? 1, 8);
                    return View(lstArticle);

                }
                else if (method == "222")
                {
                    var lstArticle = db.Articles.OrderBy(n => n.Price).Where(n => n.CategoryId == 6 && n.Status == "Y").ToPagedList(page ?? 1, 8);
                    return View(lstArticle);

                }
            }
            return View();
        }
        public ActionResult PC(int? page)
        {
            return View(db.Articles.OrderBy(n => n.Id).Where(n => n.CategoryId == 6 && n.Status == "Y").ToPagedList(page ?? 1, 8));
        }
        #endregion
        #region Ô tô và xe máy
        [HttpPost]
        public ActionResult Oto(int? page, FormCollection form)
        {
            if (form.Count > 0)
            {
                string method = form["select"].ToString();
                if (method == "111")
                {
                    var lstArticle = db.Articles.OrderByDescending(n => n.Create_Date).Where(n => n.CategoryId == 3 && n.Status == "Y").ToPagedList(page ?? 1, 8);
                    return View(lstArticle);

                }
                else if (method == "333")
                {
                    var lstArticle = db.Articles.OrderByDescending(n => n.Price).Where(n => n.CategoryId == 3 && n.Status == "Y").ToPagedList(page ?? 1, 8);
                    return View(lstArticle);

                }
                else if (method == "222")
                {
                    var lstArticle = db.Articles.OrderBy(n => n.Price).Where(n => n.CategoryId == 3 && n.Status == "Y").ToPagedList(page ?? 1, 8);
                    return View(lstArticle);

                }
            }
            return View();
        }
        public ActionResult Oto(int? page)
        {
            return View(db.Articles.OrderBy(n => n.Id).Where(n => n.CategoryId == 3 && n.Status == "Y").ToPagedList(page ?? 1, 8));
        }
        #endregion
        #region Đồ dùng gia đình
        [HttpPost]
        public ActionResult do_dung_gia_dinh(int? page, FormCollection form)
        {
            if (form.Count > 0)
            {
                string method = form["select"].ToString();
                if (method == "111")
                {
                    var lstArticle = db.Articles.OrderByDescending(n => n.Create_Date).Where(n => n.CategoryId == 7 && n.Status == "Y").ToPagedList(page ?? 1, 8);
                    return View(lstArticle);

                }
                else if (method == "333")
                {
                    var lstArticle = db.Articles.OrderByDescending(n => n.Price).Where(n => n.CategoryId == 7 && n.Status == "Y").ToPagedList(page ?? 1, 8);
                    return View(lstArticle);

                }
                else if (method == "222")
                {
                    var lstArticle = db.Articles.OrderBy(n => n.Price).Where(n => n.CategoryId == 7 && n.Status == "Y").ToPagedList(page ?? 1, 8);
                    return View(lstArticle);

                }
            }
            return View();
        }
        public ActionResult do_dung_gia_dinh(int? page)
        {
            return View(db.Articles.OrderBy(n => n.Id).Where(n => n.CategoryId == 7 && n.Status == "Y").ToPagedList(page ?? 1, 8));
        }
        #endregion
        #region Nhà đất
        [HttpPost]
        public ActionResult Nha_dat(int? page, FormCollection form)
        {
            if (form.Count > 0)
            {
                string method = form["select"].ToString();
                if (method == "111")
                {
                    var lstArticle = db.Articles.OrderByDescending(n => n.Create_Date).Where(n => n.CategoryId == 8 && n.Status == "Y").ToPagedList(page ?? 1, 8);
                    return View(lstArticle);

                }
                else if (method == "333")
                {
                    var lstArticle = db.Articles.OrderByDescending(n => n.Price).Where(n => n.CategoryId == 8 && n.Status == "Y").ToPagedList(page ?? 1, 8);
                    return View(lstArticle);

                }
                else if (method == "222")
                {
                    var lstArticle = db.Articles.OrderBy(n => n.Price).Where(n => n.CategoryId == 8 && n.Status == "Y").ToPagedList(page ?? 1, 8);
                    return View(lstArticle);

                }
            }
            return View();
        }
        public ActionResult Nha_dat(int? page)
        {
            return View(db.Articles.OrderBy(n => n.Id).Where(n => n.CategoryId == 8 && n.Status == "Y").ToPagedList(page ?? 1, 8));
        }
        #endregion
        #region Thú cưng
        [HttpPost]
        public ActionResult Thu_cung(int? page, FormCollection form)
        {
            if (form.Count > 0)
            {
                string method = form["select"].ToString();
                if (method == "111")
                {
                    var lstArticle = db.Articles.OrderByDescending(n => n.Create_Date).Where(n => n.CategoryId == 9 && n.Status == "Y").ToPagedList(page ?? 1, 8);
                    return View(lstArticle);

                }
                else if (method == "333")
                {
                    var lstArticle = db.Articles.OrderByDescending(n => n.Price).Where(n => n.CategoryId == 9 && n.Status == "Y").ToPagedList(page ?? 1, 8);
                    return View(lstArticle);

                }
                else if (method == "222")
                {
                    var lstArticle = db.Articles.OrderBy(n => n.Price).Where(n => n.CategoryId == 9 && n.Status == "Y").ToPagedList(page ?? 1, 8);
                    return View(lstArticle);

                }
            }
            return View();
        }
        public ActionResult Thu_cung(int? page)
        {
            return View(db.Articles.OrderBy(n => n.Id).Where(n => n.CategoryId == 9 && n.Status == "Y").ToPagedList(page ?? 1, 8));
        }
        #endregion
        #region Books
        [HttpPost]
        public ActionResult Books(int? page, FormCollection form)
        {
            if (form.Count > 0)
            {
                string method = form["select"].ToString();
                if (method == "111")
                {
                    var lstArticle = db.Articles.OrderByDescending(n => n.Create_Date).Where(n => n.CategoryId == 10 && n.Status == "Y").ToPagedList(page ?? 1, 8);
                    return View(lstArticle);

                }
                else if (method == "333")
                {
                    var lstArticle = db.Articles.OrderByDescending(n => n.Price).Where(n => n.CategoryId == 10 && n.Status == "Y").ToPagedList(page ?? 1, 8);
                    return View(lstArticle);

                }
                else if (method == "222")
                {
                    var lstArticle = db.Articles.OrderBy(n => n.Price).Where(n => n.CategoryId == 10 && n.Status == "Y").ToPagedList(page ?? 1, 8);
                    return View(lstArticle);

                }
            }
            return View();
        }
        public ActionResult Books(int? page)
        {
            return View(db.Articles.OrderBy(n => n.Id).Where(n => n.CategoryId == 10 && n.Status == "Y").ToPagedList(page ?? 1, 8));
        }
        #endregion
        #region Quan_ao
        [HttpPost]
        public ActionResult Quan_ao(int? page, FormCollection form)
        {
            if (form.Count > 0)
            {
                string method = form["select"].ToString();
                if (method == "111")
                {
                    var lstArticle = db.Articles.OrderByDescending(n => n.Create_Date).Where(n => n.CategoryId == 11 && n.Status == "Y").ToPagedList(page ?? 1, 8);
                    return View(lstArticle);

                }
                else if (method == "333")
                {
                    var lstArticle = db.Articles.OrderByDescending(n => n.Price).Where(n => n.CategoryId == 11 && n.Status == "Y").ToPagedList(page ?? 1, 8);
                    return View(lstArticle);

                }
                else if (method == "222")
                {
                    var lstArticle = db.Articles.OrderBy(n => n.Price).Where(n => n.CategoryId == 11 && n.Status == "Y").ToPagedList(page ?? 1, 8);
                    return View(lstArticle);

                }
            }
            return View();
        }
        public ActionResult Quan_ao(int? page)
        {
            return View(db.Articles.OrderBy(n => n.Id).Where(n => n.CategoryId == 11 && n.Status == "Y").ToPagedList(page ?? 1, 8));
        }
        #endregion
        #region Do_dung_tre_em
        [HttpPost]
        public ActionResult Do_dung_tre_em(int? page, FormCollection form)
        {
            if (form.Count > 0)
            {
                string method = form["select"].ToString();
                if (method == "111")
                {
                    var lstArticle = db.Articles.OrderByDescending(n => n.Create_Date).Where(n => n.CategoryId == 12 && n.Status == "Y").ToPagedList(page ?? 1, 8);
                    return View(lstArticle);

                }
                else if (method == "333")
                {
                    var lstArticle = db.Articles.OrderByDescending(n => n.Price).Where(n => n.CategoryId == 12 && n.Status == "Y").ToPagedList(page ?? 1, 8);
                    return View(lstArticle);

                }
                else if (method == "222")
                {
                    var lstArticle = db.Articles.OrderBy(n => n.Price).Where(n => n.CategoryId == 12 && n.Status == "Y").ToPagedList(page ?? 1, 8);
                    return View(lstArticle);

                }
            }
            return View();
        }
        public ActionResult Do_dung_tre_em(int? page)
        {
            return View(db.Articles.OrderBy(n => n.Id).Where(n => n.CategoryId == 12 && n.Status == "Y").ToPagedList(page ?? 1, 8));
        }
        #endregion
        #region Do_kim_khi
        [HttpPost]
        public ActionResult Do_kim_khi(int? page, FormCollection form)
        {
            if (form.Count > 0)
            {
                string method = form["select"].ToString();
                if (method == "111")
                {
                    var lstArticle = db.Articles.OrderByDescending(n => n.Create_Date).Where(n => n.CategoryId == 13 && n.Status == "Y").ToPagedList(page ?? 1, 8);
                    return View(lstArticle);

                }
                else if (method == "333")
                {
                    var lstArticle = db.Articles.OrderByDescending(n => n.Price).Where(n => n.CategoryId == 13 && n.Status == "Y").ToPagedList(page ?? 1, 8);
                    return View(lstArticle);

                }
                else if (method == "222")
                {
                    var lstArticle = db.Articles.OrderBy(n => n.Price).Where(n => n.CategoryId == 13 && n.Status == "Y").ToPagedList(page ?? 1, 8);
                    return View(lstArticle);

                }
            }
            return View();
        }
        public ActionResult Do_kim_khi(int? page)
        {
            return View(db.Articles.OrderBy(n => n.Id).Where(n => n.CategoryId == 13 && n.Status == "Y").ToPagedList(page ?? 1, 8));
        }
        #endregion
        #region Dich_vu
        [HttpPost]
        public ActionResult Dich_vu(int? page, FormCollection form)
        {
            if (form.Count > 0)
            {
                string method = form["select"].ToString();
                if (method == "111")
                {
                    var lstArticle = db.Articles.OrderByDescending(n => n.Create_Date).Where(n => n.CategoryId == 14 && n.Status == "Y").ToPagedList(page ?? 1, 8);
                    return View(lstArticle);

                }
                else if (method == "333")
                {
                    var lstArticle = db.Articles.OrderByDescending(n => n.Price).Where(n => n.CategoryId == 14 && n.Status == "Y").ToPagedList(page ?? 1, 8);
                    return View(lstArticle);

                }
                else if (method == "222")
                {
                    var lstArticle = db.Articles.OrderBy(n => n.Price).Where(n => n.CategoryId == 14 && n.Status == "Y").ToPagedList(page ?? 1, 8);
                    return View(lstArticle);

                }
            }
            return View();
        }
        public ActionResult Dich_vu(int? page)
        {
            return View(db.Articles.OrderBy(n => n.Id).Where(n => n.CategoryId == 14 && n.Status == "Y").ToPagedList(page ?? 1, 8));
        }
        #endregion
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