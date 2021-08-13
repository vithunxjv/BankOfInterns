using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOI.Models;

namespace BOI.Controllers
{
   
    public class AdminController : Controller
    {
        BOIModelContext db = new BOIModelContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(decimal id)
        {
            var inp = db.ValidIdVerify(id).FirstOrDefault();
            if (inp != null)
            {
                ViewBag.Message = null;
            }
            else
            {
                ViewBag.Message = "Invalid UserID";
                return View();
            }
            return RedirectToAction("CustDetails", new { id = id });
        }
        public ActionResult CustDetails(decimal id)
        {
            return View(db.ViewUserDetails(id).SingleOrDefault());

        }

        [HttpPost]
        public ActionResult CustList(string branch)
        {
           return View(db.ViewCustomer_List(branch).ToList());
        }
    }
}
  