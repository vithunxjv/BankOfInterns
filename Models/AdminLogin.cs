namespace BOI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AdminLogin")]
    public partial class AdminLogin
    {
        [Key]
        [Column(TypeName = "numeric")]
        public decimal UserId { get; set; }

        [Required]
        public string Pwd { get; set; }
    }
}
