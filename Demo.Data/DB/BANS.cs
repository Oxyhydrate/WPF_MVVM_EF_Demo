namespace Demo.Data.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BEE.BANS")]
    public partial class BANS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BANS()
        {
            BILLS = new HashSet<BILLS>();
            NUMBERS = new HashSet<NUMBERS>();
        }

        public decimal SR_SUBSCRIBE { get; set; }

        [Key]
        [StringLength(15)]
        public string BAN { get; set; }

        public virtual ABONENTS ABONENTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BILLS> BILLS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NUMBERS> NUMBERS { get; set; }


    }
}
