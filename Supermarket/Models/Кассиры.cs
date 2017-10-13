namespace Supermarket.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Кассиры
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Кассиры()
        {
            Чеки = new HashSet<Чеки>();
            Смены = new HashSet<Смены>();
        }

        [Key]
        [Column("ID кассира")]
        public Guid ID_кассира { get; set; }

        [Required]
        [StringLength(50)]
        public string Фамилия { get; set; }

        [Required]
        [StringLength(50)]
        public string Имя { get; set; }

        [StringLength(50)]
        public string Отчество { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Чеки> Чеки { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Смены> Смены { get; set; }
    }
}
