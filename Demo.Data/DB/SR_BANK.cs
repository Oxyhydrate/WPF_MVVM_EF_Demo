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
    }
}
