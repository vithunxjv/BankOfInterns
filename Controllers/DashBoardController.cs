using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOI.Models;

namespace BOI.Controllers
{
    
    public class DashBoardController : Controller
    {
        // GET: DashBoard
        BOIModelContext db = new BOIModelContext();

        public ActionResult Menu()
        {
            return View();
        }
        public ActionResult BranchDetails(decimal id)
        {
            var s = db.GetBranchDetails(id).SingleOrDefault();
            return View(s);
        }
        public ActionResult AcSummary(decimal id)
        {
            var s = db.GetAcSummary(id).ToList();
            return View(s);
        }

        public ActionResult AcStatement()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AcStatement(decimal id,DateTime? from,DateTime? to)
        {
            var s = db.GetAcStatement(id, from, to).ToList();
            return View(s);
        }


    }
}