namespace Supermarket.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("История изменения цен")]
    public partial class История_изменения_цен
    {
        [Key]
        [Column("ID товара", Order = 0)]
        public Guid ID_товара { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "date")]
        public DateTime Дата { get; set; }

        public double Цена { get; set; }

        public virtual Товары Товары { get; set; }
    }
}
