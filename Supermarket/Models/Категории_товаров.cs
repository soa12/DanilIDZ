namespace Supermarket.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Категории товаров")]
    public partial class Категории_товаров
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Категории_товаров()
        {
            Товары = new HashSet<Товары>();
        }

        [Key]
        [Column("Код категории")]
        public int Код_категории { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Наименование { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Товары> Товары { get; set; }
    }
}
