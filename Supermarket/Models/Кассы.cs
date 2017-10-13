namespace Supermarket.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Кассы
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Кассы()
        {
            Смены = new HashSet<Смены>();
        }

        [Key]
        [Column("Номер кассы")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Номер_кассы { get; set; }

        [Column("Поддержка безналичного расчета")]
        public bool Поддержка_безналичного_расчета { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Смены> Смены { get; set; }
    }
}
