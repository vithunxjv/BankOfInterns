namespace BOI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NewAcc")]
    public partial class NewAcc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NewAcc()
        {
            AccountMasters = new HashSet<AccountMaster>();
            Logins = new HashSet<Login>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal CustId { get; set; }

        [Required]
        [StringLength(10)]
        public string Title { get; set; }

        [Required]
        [StringLength(50)]
        public string Fname { get; set; }

        [Required]
        [StringLength(50)]
        public string Lname { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Phone { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        public string PAN { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Aadhar { get; set; }

        [Column(TypeName = "date")]
        public DateTime DOB { get; set; }

        [Required]
        [StringLength(50)]
        public string ResAdd { get; set; }

        [Required]
        [StringLength(50)]
        public string BranchName { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Pincode { get; set; }

        [Required]
        [StringLength(50)]
        public string State { get; set; }

        [Required]
        [StringLength(50)]
        public string PerAdd { get; set; }

        [Required]
        [StringLength(50)]
        public string PerAdd1 { get; set; }

        [Required]
        [StringLength(50)]
        public string City01 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal pincode01 { get; set; }

        [Required]
        [StringLength(50)]
        public string state01 { get; set; }

        [Required]
        [StringLength(10)]
        public string Gender { get; set; }

        [Required]
        [StringLength(50)]
        public string Occupation { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Income { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AccountMaster> AccountMasters { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Login> Logins { get; set; }
    }
}
