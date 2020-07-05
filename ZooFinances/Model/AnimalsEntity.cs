namespace ZooFinances.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

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
