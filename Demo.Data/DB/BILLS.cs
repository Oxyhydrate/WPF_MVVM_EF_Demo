namespace Demo.Data.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BEE.BILLS")]
    public partial class BILLS
    {
        [StringLength(15)]
        public string BAN { get; set; }

        [Key]
        [StringLength(10)]
        public string BILL { get; set; }

        public DateTime? DATE_BILL { get; set; }

        public decimal? SUMM { get; set; }

        public decimal? ORDER_ID { get; set; }
    }
}
