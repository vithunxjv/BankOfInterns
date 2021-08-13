using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOI.Models;

namespace BOI.Controllers
{
    
    public class LoginController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult AdminView()
        {
            return RedirectToAction("Index", "Admin");
        }

        public ActionResult UserView()
        {
            return RedirectToAction("Menu", "Dashboard");
        }

        [HttpPost]
        public ActionResult Verify(Login model)
        {
            BOIModelContext db = new BOIModelContext();
            var s = db.LoginCheck(model.UserId, model.Pwd);
           Session["uid"] = model.UserId;
            var item = s.FirstOrDefault();
            if (item == 1)
            {
                return RedirectToAction("Index","Admin");
            }
            else if (item == 2)
            {
                return RedirectToAction("Menu","DashBoard",new { id =Session["uid"] });
            }
            else
            {
                model.LoginErrorMsg = "Invalid Username or Password";
                return View("Login", model);
            }
        }
    }
}