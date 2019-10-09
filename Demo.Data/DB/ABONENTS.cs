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
        [Key]
        public decimal KOD_SUBSCRIBE { get; set; }

        [StringLength(2000)]
        public string OWNER { get; set; }

        public decimal? KOD_STATUS { get; set; }

        public int? INN_PASSPORT { get; set; }

        public int? KPP { get; set; }

        public int? BIK { get; set; }

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
    }
}
