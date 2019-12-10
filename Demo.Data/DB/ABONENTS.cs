namespace Demo.Data.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BEE.ABONENTS")]
    public partial class ABONENTS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ABONENTS()
        {
            BANS = new HashSet<BANS>();
        }

        [Key]
        public decimal KOD_SUBSCRIBE { get; set; }

        [StringLength(2000)]
        public string OWNER { get; set; }

        public decimal? KOD_STATUS { get; set; }

        public int? INN_PASSPORT { get; set; }

        public int? KPP { get; set; }

        public int? BIKN { get; set; }

        [StringLength(20)]
        public string R_ACCOUNT { get; set; }

        public DateTime? CREATE_DATE { get; set; }

        public DateTime? LAST_MOD { get; set; }

        [StringLength(10)]
        public string OKPO { get; set; }

        [StringLength(13)]
        public string OGRN { get; set; }

        [StringLength(6)]
        public string OKVED { get; set; }

        public decimal? LEGAL_ADDRESS { get; set; }

        public decimal? PHISIC_ADDRESS { get; set; }

        [StringLength(100)]
        public string DIRECTOR { get; set; }

        [StringLength(100)]
        public string GLAVBUH { get; set; }

        public decimal? GOS_CONTRACT_STATUS { get; set; }

        [StringLength(9)]
        public string BIK { get; set; }

        public virtual COMMENTS COMMENTS { get; set; }

        public virtual CONTACTS CONTACTS { get; set; }

        public virtual CONTACTS CONTACTS1 { get; set; }

        public virtual SR_BANK SR_BANK { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BANS> BANS { get; set; }

        [NotMapped]
        public string SelectedBAN { get; set; }

        [NotMapped]
        public string SelectedMSISDN { get; set; }
    }
}
