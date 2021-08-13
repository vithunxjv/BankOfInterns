namespace BOI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TransTable")]
    public partial class TransTable
    {
        [Column(TypeName = "numeric")]
        public decimal? AccNo { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FromAccNo { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ToAccNo { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? BeneficiaryID { get; set; }

        [Column(TypeName = "smallmoney")]
        public decimal? Amount { get; set; }

        [Column(TypeName = "date")]
        public DateTime? TransDate { get; set; }

        public TimeSpan? TransTime { get; set; }

        [StringLength(50)]
        public string TransType { get; set; }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal TransactionID { get; set; }

        [StringLength(50)]
        public string Remarks { get; set; }

        public virtual AccountMaster AccountMaster { get; set; }

        public virtual Beneficiary Beneficiary { get; set; }
    }
}
