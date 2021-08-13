using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using BOI.Models;

namespace BOI.Controllers
{
    
    public class TransactionController : Controller
    {
        // GET: Transaction
        BOIModelContext db = new BOIModelContext();
        List<Beneficiary> Beneficiary = new List<Beneficiary>();
        List<TransTable> TransTable = new List<TransTable>();
        public ActionResult Benifi(int id = 0)
        {
            Beneficiary b = new Beneficiary();
            ViewBag.BeneficiaryType = new SelectList(db.Beneficiaries, "BeneficiaryType");
            return View(b);

        }
        [HttpPost]
        public ActionResult Benifi(Beneficiary b)
        {
            using (BOIModelContext db = new BOIModelContext())
            {
                if (db.Beneficiaries.Any(x => x.BenAccNo == b.BenAccNo))
                {
                    ViewBag.DuplicatMessage = "Beneficiary already Exists";
                    return View("Benifi", b);
                }
                else
                {
                    db.Beneficiaries.Add(b);
                    db.SaveChanges();

                }

            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Beneficiary Added";
            return View("Benifi", new Beneficiary());

        }
        public ActionResult Trans(int i = 0)
        {
            TransTable t = new TransTable();
            return View(t);
        }
        [HttpPost]
        public ActionResult Trans(TransTable t)
        {
            using (BOIModelContext sb = new BOIModelContext())
            {
                sb.TransTables.Add(t);
                sb.SaveChanges();
            }
            return View("EnterAccNo");
        }
        [HttpPost]
        public ActionResult EnterAccNo(EnterAccNo model)
        {
            BOIModelContext bce = new BOIModelContext();
            var id = bce.GetEmail2(model.AccNo);
            var item1 = id.FirstOrDefault();
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(item1);
                mail.From = new MailAddress("bankofinterns@gmail.com");
                mail.Subject = "OTP for reset password";
                string userMessage = "";

                Random r = new Random();
                string OTP = r.Next(1000, 9999).ToString();

                userMessage = userMessage + "<br/><b>OTP:</b> " + OTP;

                string Body = "Your SECRET One Time Password (OTP) for Online Banking reset password is:<br/>" + userMessage + "<br/><br/>Do not share it with anyone.";
                mail.Body = Body;
                mail.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com", //SMTP Server Address of gmail
                    Port = 587,
                    Credentials = new System.Net.NetworkCredential("bankofinterns@gmail.com", "ctsprojectmates"),
                    // Smtp Email ID and Password For authentication
                    EnableSsl = true
                };
                smtp.Send(mail);

                Session["OTP"] = OTP;

                return RedirectToAction("verify");
            }
            catch
            {
                model.AccNoErrorMsg = "Incorrect Account Number";
                return View("EnterAccNo", model);
            }
        }
        public ActionResult verify(EnterOtp model,TransTable t)
        {

            if (Session["OTP"].ToString() == model.OTP)
            {
                
                return RedirectToAction("TransDetail");
            }
            else
            {
                model.OtpErrorMsg = "Incorrect OTP";
                return View("verify", model);
            }

        }

        public ActionResult TransDetail()
        {

            var s = db.TransDetails().FirstOrDefault();
            return View(s);
        }

    }
}
