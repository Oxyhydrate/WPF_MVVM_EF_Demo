namespace Demo.Data.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BEE.COMMENTS")]
    public partial class COMMENTS
    {
        [Key]
        public decimal KOD_SUBSCRIBE { get; set; }

        [StringLength(2000)]
        public string COMM { get; set; }

        public virtual ABONENTS ABONENTS { get; set; }
    }
}
