namespace ZooFinances.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.DirectoryServices.ActiveDirectory;

    [Table("AnimalsTable")]
    public partial class AnimalsEntity
    {
        [Key]
        public int AnimalId { get; set; }

        [Required]
        [StringLength(50)]
        public string AnimalName { get; set; }

        [Required]
        [StringLength(50)]
        public string AnimalType { get; set; }

        public virtual AnimalTypeEntity AnimalTypeTable { get; set; }
    }
}
