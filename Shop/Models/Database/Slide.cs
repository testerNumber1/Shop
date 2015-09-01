namespace Shop.Models.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Slide")]
    public partial class Slide
    {
        public int ID { get; set; }

        [Column(TypeName = "image")]
        public byte[] Image { get; set; }

        [StringLength(10)]
        public string Url { get; set; }

        public int? OrderDisplay { get; set; }

        public bool? State { get; set; }
    }
}
