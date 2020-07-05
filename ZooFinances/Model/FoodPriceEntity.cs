namespace ZooFinances.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("FoodPriceTable")]
    public partial class FoodPriceEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FoodPriceEntity()
        {
            AnimalTypeTable = new HashSet<AnimalTypeEntity>();
        }

        [Key]
        [StringLength(50)]
        public string FoodType { get; set; }

        [Column(TypeName = "money")]
        public decimal FoodPrice { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AnimalTypeEntity> AnimalTypeTable { get; set; }
    }
}
