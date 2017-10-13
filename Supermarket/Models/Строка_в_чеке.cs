namespace Supermarket.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Строка в чеке")]
    public partial class Строка_в_чеке
    {
        [Key]
        [Column("ID чека", Order = 0)]
        public Guid ID_чека { get; set; }

        [Key]
        [Column("Номер строки", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Номер_строки { get; set; }

        [Column("ID товара")]
        public Guid ID_товара { get; set; }

        public int Количество { get; set; }

        public virtual Чеки Чеки { get; set; }

        public virtual Товары Товары { get; set; }
    }
}
