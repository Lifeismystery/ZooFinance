namespace ZooFinances.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AnimalTypeTable")]
    public partial class AnimalTypeTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AnimalTypeTable()
        {
            AnimalsTable = new HashSet<AnimalsTable>();
        }

        [Key]
        [StringLength(50)]
        public string Animal_Type { get; set; }

        [Required]
        [StringLength(50)]
        public string Food_Type { get; set; }

        public double Food_Rate_Per_Day { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AnimalsTable> AnimalsTable { get; set; }

        public virtual FoodPriceTable FoodPriceTable { get; set; }
    }
}
