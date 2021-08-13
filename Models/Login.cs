namespace BOI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Login")]
    public partial class Login
    {
        [Key]
        [Column(TypeName = "numeric")]
        public decimal UserId { get; set; }

        [Required]
        public string Pwd { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CustId { get; set; }

        public virtual NewAcc NewAcc { get; set; }
        public string LoginErrorMsg { get; internal set; }
    }
}
