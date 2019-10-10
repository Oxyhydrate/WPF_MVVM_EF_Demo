namespace Demo.Data.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BEE.NUMBERS")]
    public partial class NUMBERS
    {
        public decimal? KOD_SUBSCRIBE { get; set; }

        [StringLength(15)]
        public string BAN { get; set; }

        [Key]
        [StringLength(10)]
        public string MSISDN { get; set; }

        [StringLength(18)]
        public string SIM { get; set; }

        public DateTime? CREATE_DATE { get; set; }

        [StringLength(50)]
        public string TARIFF { get; set; }

        public decimal? STATUS { get; set; }

        public virtual BANS BANS { get; set; }
    }
}
