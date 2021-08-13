using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using BOI.Models;

namespace BOI.Controllers
{
    
    public class ResetPasswordController : Controller
    {
        [HttpGet]
        public ActionResult EnterUserId()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ResetPwd(ResetPwd model)
        {
            BOIModelContext dc = new BOIModelContext();
            dc.UpdatePwd(model.UserId, model.NewPassword);

            return View("Login");

        }

        [HttpPost]
        public ActionResult NewPwd(EnterOtp model)
        {

            if (Session["OTP"].ToString() == model.OTP)
            {
                return View("ResetPwd");
            }
            else
            {
                model.OtpErrorMsg = "Incorrect OTP";
                return View("NewPwd", model);
            }

        }

        [HttpPost]
        public ActionResult VerifyOtp(EnterUserId model)
        {
            BOIModelContext bce = new BOIModelContext();
            var id = bce.GetEmail(model.UserId);
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

                return View("NewPwd");
            }
            catch
            {
                model.UserIdErrorMsg = "Invalid UserId";
                return View("EnterUserId", model);
            }
        }
    }
}