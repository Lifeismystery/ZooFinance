namespace ZooFinances.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LogbookModel : DbContext
    {
        public LogbookModel()
            : base("name=LogookModel")
        {
        }

        public virtual DbSet<AnimalsTable> AnimalsTable { get; set; }
        public virtual DbSet<AnimalTypeTable> AnimalTypeTable { get; set; }
        public virtual DbSet<FoodPriceTable> FoodPriceTable { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnimalTypeTable>()
                .HasMany(e => e.AnimalsTable)
                .WithRequired(e => e.AnimalTypeTable)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FoodPriceTable>()
                .Property(e => e.Food_Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FoodPriceTable>()
                .HasMany(e => e.AnimalTypeTable)
                .WithRequired(e => e.FoodPriceTable)
                .WillCascadeOnDelete(false);
        }
    }
}
