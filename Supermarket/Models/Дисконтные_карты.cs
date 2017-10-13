namespace Supermarket.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Дисконтные карты")]
    public partial class Дисконтные_карты
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Дисконтные_карты()
        {
            Чеки = new HashSet<Чеки>();
        }

        [Key]
        [Column("Номер карты")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Номер_карты { get; set; }

        [Column("Величина скидки")]
        public int Величина_скидки { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Чеки> Чеки { get; set; }
    }
}
