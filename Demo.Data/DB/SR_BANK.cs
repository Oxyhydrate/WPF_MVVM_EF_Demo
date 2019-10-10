namespace Demo.Data.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BEE.SR_BANK")]
    public partial class SR_BANK
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SR_BANK()
        {
            ABONENTS = new HashSet<ABONENTS>();
        }

        [Key]
        [StringLength(9)]
        public string BIK { get; set; }

        [Required]
        [StringLength(150)]
        public string BANK_NAME { get; set; }

        [StringLength(20)]
        public string K_ACCOUNT { get; set; }

        [StringLength(150)]
        public string TOWN_NAME { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ABONENTS> ABONENTS { get; set; }
    }
}
