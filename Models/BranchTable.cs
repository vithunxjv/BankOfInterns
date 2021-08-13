namespace BOI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BranchTable")]
    public partial class BranchTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BranchTable()
        {
            AccountMasters = new HashSet<AccountMaster>();
        }

        [Key]
        [StringLength(50)]
        public string IFSCCode { get; set; }

        [Required]
        [StringLength(50)]
        public string BranchName { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [Column(TypeName = "numeric")]
        public decimal BranchCode { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AccountMaster> AccountMasters { get; set; }
    }
}
