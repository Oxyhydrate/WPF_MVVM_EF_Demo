namespace Demo.Data.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BEE.CONTACTS")]
    public partial class CONTACTS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CONTACTS()
        {
            ABONENTS = new HashSet<ABONENTS>();
            ABONENTS1 = new HashSet<ABONENTS>();
        }

        public decimal ID { get; set; }

        public int? ZIP { get; set; }

        [StringLength(200)]
        public string COUNTRY { get; set; }

        [StringLength(200)]
        public string REGION { get; set; }

        public decimal? PLACETYPE { get; set; }

        [StringLength(100)]
        public string PLACENAME { get; set; }

        public decimal? STREETTYPE { get; set; }

        [StringLength(100)]
        public string STREETNAME { get; set; }

        [StringLength(50)]
        public string HOUSE { get; set; }

        [StringLength(50)]
        public string FLAT { get; set; }

        [StringLength(50)]
        public string TELEPHONE { get; set; }

        [StringLength(50)]
        public string FAX { get; set; }

        [StringLength(50)]
        public string EMAIL { get; set; }

        [StringLength(200)]
        public string CONTACTNAME { get; set; }

        public decimal? KOD_SUBSCRIBE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ABONENTS> ABONENTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ABONENTS> ABONENTS1 { get; set; }
    }
}
