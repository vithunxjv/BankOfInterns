using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOI.Models;

namespace AccOpenV.Controllers
{
    
    public class NewAccController : Controller
    {
        // GET: NewAcc
        BOIModelContext db = new BOIModelContext();
        public ActionResult AccOpen()
        {
            NewAcc accopen = new NewAcc();
            ViewBag.gender = new SelectList(db.NewAccs, "Cust_id", "gender");
            ViewBag.branchname = new SelectList(db.NewAccs, "Cust_id", "branchname");
            return View(accopen);
        }
        [HttpPost]
        public ActionResult AccOpen(NewAcc accopen,HttpPostedFileBase panpdf)
        {
            using (BOIModelContext db = new BOIModelContext())
            {
                db.NewAccs.Add(accopen);
                db.SaveChanges();

            }
            ModelState.Clear();
            return RedirectToAction("AccSuccess");
        }

        public ActionResult AccSuccess()
        {
           return View(db.MailingDet().FirstOrDefault());
        }
    }
}