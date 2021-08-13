using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BOI.Models
{
    public class EnterOtp
    {
        [Required]
        public string OTP { get; set; }
        public string OtpErrorMsg { get;  set; }
    }
}