using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supermarket.Models.Товары_в_чеке
{
    public partial class ТоварВЧеке : IEnumerable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public ТоварВЧеке() 
        //{ 
        // История_изменения_цен = new HashSet<История_изменения_цен>(); 
        // Строка_в_чеке = new HashSet<Строка_в_чеке>(); 
        //} 

        //[Key] 
        [Column("ID товара")]
        public Guid ID_товара { get; set; }

        [Required]
        [StringLength(50)]
        public string Наименование { get; set; }

        public int Количество { get; set; }

        public int Номер { get; set; }

        //public Guid Id_чека { get; set; }

        //[Column("Код категории")] 
        //public int Код_категории { get; set; } 

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<История_изменения_цен> История_изменения_цен { get; set; } 

        //public virtual Категории_товаров Категории_товаров { get; set; } 

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Строка_в_чеке> Строка_в_чеке { get; set; } 
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}