namespace ZooFinances.Model
{
    using System.Data.Entity;

    public partial class LogbookModel : DbContext
    {
        public LogbookModel()
            : base("name=LogookModel")
        {
        }

        public virtual DbSet<AnimalsEntity> AnimalsTable { get; set; }
        public virtual DbSet<AnimalTypeEntity> AnimalTypeTable { get; set; }
        public virtual DbSet<FoodPriceEntity> FoodPriceTable { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnimalTypeEntity>()
                .HasMany(e => e.AnimalsTable)
                .WithRequired(e => e.AnimalTypeTable)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FoodPriceEntity>()
                .Property(e => e.FoodPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FoodPriceEntity>()
                .HasMany(e => e.AnimalTypeTable)
                .WithRequired(e => e.FoodPriceTable)
                .WillCascadeOnDelete(false);
        }
    }
}
