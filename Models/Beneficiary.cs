namespace BOI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Beneficiary")]
    public partial class Beneficiary
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Beneficiary()
        {
            TransTables = new HashSet<TransTable>();
        }

        [Column(TypeName = "numeric")]
        public decimal AccNo { get; set; }

        [Column(TypeName = "numeric")]
        public decimal BenAccNo { get; set; }

        [Required]
        [StringLength(50)]
        public string BenName { get; set; }

        [StringLength(50)]
        public string NickName { get; set; }

        [Required]
        [StringLength(10)]
        public string BenBankName { get; set; }

        [Required]
        [StringLength(50)]
        public string IFSCCode { get; set; }

        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal BeneficiaryID { get; set; }

        [StringLength(4)]
        public string BeneficiaryType { get; set; }

        [StringLength(50)]
        public string Remarks { get; set; }

        public virtual AccountMaster AccountMaster { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TransTable> TransTables { get; set; }
    }
}
