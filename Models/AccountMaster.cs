namespace BOI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AccountMaster")]
    public partial class AccountMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AccountMaster()
        {
            Beneficiaries = new HashSet<Beneficiary>();
            TransTables = new HashSet<TransTable>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        public decimal AccNo { get; set; }

        [Required]
        [StringLength(30)]
        public string AccHolder { get; set; }

        [Required]
        [StringLength(50)]
        public string IFSCCode { get; set; }

        [StringLength(10)]
        public string AccType { get; set; }

        [Column(TypeName = "date")]
        public DateTime? AccOpenDate { get; set; }

        public int AccBalance { get; set; }

        [StringLength(10)]
        public string AccStatus { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CustId { get; set; }

        public virtual NewAcc NewAcc { get; set; }

        public virtual BranchTable BranchTable { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Beneficiary> Beneficiaries { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TransTable> TransTables { get; set; }
    }
}
