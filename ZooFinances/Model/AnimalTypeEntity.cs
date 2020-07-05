namespace ZooFinances.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("AnimalTypeTable")]
    public partial class AnimalTypeEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AnimalTypeEntity()
        {
            AnimalsTable = new HashSet<AnimalsEntity>();
        }

        [Key]
        [StringLength(50)]
        public string AnimalType { get; set; }

        [Required]
        [StringLength(50)]
        public string FoodType { get; set; }

        public double FoodRatePerDay { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AnimalsEntity> AnimalsTable { get; set; }

        public virtual FoodPriceEntity FoodPriceTable { get; set; }
    }
}
