namespace ZooFinances.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AnimalsTable")]
    public partial class AnimalsTable
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Animal_Type { get; set; }

        public virtual AnimalTypeTable AnimalTypeTable { get; set; }
    }
}
