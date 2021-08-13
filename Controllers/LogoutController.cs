using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BOI.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
    public class LogoutController : Controller
    {
        // GET: Logout
       
        
        public ActionResult Logout()
        {
            Session["uid"] = null;
            Session.Clear();
            Session.Abandon();
            FormsAuthentication.SignOut();
            return View("Logout");
            //HttpContext.Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            //HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //HttpContext.Response.Cache.SetNoStore();

            //Session.Clear();
            //Session.Abandon();
            //Session.RemoveAll();
            //return View("Logout");
        }
    }
}