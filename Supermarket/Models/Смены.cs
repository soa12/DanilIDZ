namespace Supermarket.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Смены
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Смены()
        {
            Чеки = new HashSet<Чеки>();
        }

        [Key]
        [Column("ID смены")]
        public Guid ID_смены { get; set; }

        [Column("Дата начала работы")]
        public DateTime Дата_начала_работы { get; set; }

        [Column("Дата окончания работы")]
        public DateTime Дата_окончания_работы { get; set; }

        [Column("ID кассира")]
        public Guid ID_кассира { get; set; }

        [Column("Номер кассы")]
        public int Номер_кассы { get; set; }

        public virtual Кассиры Кассиры { get; set; }

        public virtual Кассы Кассы { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Чеки> Чеки { get; set; }
    }
}
