namespace ZooFinances.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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
        public string Food_Type { get; set; }

        [Column(TypeName = "money")]
        public decimal Food_Price { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AnimalTypeEntity> AnimalTypeTable { get; set; }
    }
}
