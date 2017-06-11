using ADS.APP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADS.APP.Areas.Admin.Controllers
{
    public class StaffController : Controller
    {
        ADS_Entities db = new ADS_Entities();
        // GET: Admin/Staff
        public ActionResult Index()
        {
            if (Session["AdminLogin"] == null)
            {
                return RedirectToAction("Login", "AdminUser", new { Areas = "Admin" });
            }
            else
            {
                List<Staff> lstCategory = db.Staffs.ToList();
                return View(lstCategory);
            }
        }
        public ActionResult StaffCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult StaffCreate(Staff staff)
        {
            var Cus = db.Staffs.ToList().Find(n => n.UserName == staff.UserName);
            if (Cus == null)
            {
                Staff _cus = new Staff();
                _cus.FullName = staff.FullName;
                _cus.Status = "Y";
                _cus.UserName = staff.UserName;
                _cus.StaffType = "Y";
                _cus.PassWord = staff.PassWord;
                _cus.Address = staff.Address;
                db.Staffs.Add(_cus);
                db.SaveChanges();
                return RedirectToAction("Index", "Staff", new { Areas = "Admin" });
            }
            return View();

        }
        [HttpPost]
        public ActionResult DeleteStaff(int id)
        {
            var Staff = db.Staffs.SingleOrDefault(n => n.Id == id);
            if (Staff != null)
            {
                db.Staffs.Remove(Staff);
                db.SaveChanges();
            }
            List<Staff> Fre = db.Staffs.ToList();
            return Json(Fre, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ViewDetails(int id)
        {
            var Staff = db.Staffs.SingleOrDefault(n => n.Id == id);
            if (Staff != null)
            {
                return View(Staff);
            }
            return View();
        }
        [HttpPost]
        public ActionResult StaffEdit(Staff staf)
        {
            var staff = db.Staffs.SingleOrDefault(n => n.Id == staf.Id);
            if (staff != null)
            {
                staff.FullName = staf.FullName;
                staff.Status = staf.Status;
                staff.UserName = staf.UserName;
                staff.StaffType = staf.StaffType;
                staff.PassWord = staf.PassWord;
                staff.Address = staf.Address;
                TryUpdateModel(staff);
                db.SaveChanges();
                return RedirectToAction("Index", "Staff", new { Areas = "Admin" });
            }
            return View();
        }
    }
}