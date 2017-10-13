namespace Supermarket.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Чеки
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Чеки()
        {
            Строка_в_чеке = new HashSet<Строка_в_чеке>();
        }

        [Key]
        [Column("ID чека")]
        public Guid ID_чека { get; set; }

        [Column("Время открытия чека")]
        [DataType(DataType.DateTime)]
        public DateTime Время_открытия_чека { get; set; }

        [Column("Время закрытия чека")]
        [DataType(DataType.DateTime)]
        public DateTime Время_закрытия_чека { get; set; }

        [Column("Номер карты")]
        public int Номер_карты { get; set; }

        [Column("ID кассира")]
        public Guid ID_кассира { get; set; }

        [Column("ID смены")]
        public Guid ID_смены { get; set; }

        public bool Наличные { get; set; }

        public virtual Дисконтные_карты Дисконтные_карты { get; set; }

        public virtual Кассиры Кассиры { get; set; }

        public virtual Смены Смены { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Строка_в_чеке> Строка_в_чеке { get; set; }
    }
}
