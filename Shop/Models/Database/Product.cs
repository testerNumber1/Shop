namespace Shop.Models.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public int ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(10)]
        public string code { get; set; }

        [Column(TypeName = "image")]
        public byte[] Image { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public decimal? Price { get; set; }

        public decimal? PromotionalPrice { get; set; }

        public long? Quantity { get; set; }

        public int? OrderDisplay { get; set; }

        public bool? State { get; set; }

        public int? CategoryID { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? EditBy { get; set; }

        public DateTime? EditDate { get; set; }
    }
}
