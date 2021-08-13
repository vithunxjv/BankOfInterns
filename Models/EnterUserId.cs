using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BOI.Models
{
    public partial class EnterUserId
    {
        [Required]
        public decimal UserId { get; set; }
        public string UserIdErrorMsg { get; set; }
    }
}