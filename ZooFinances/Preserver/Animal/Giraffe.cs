using System.Linq;
using ZooFinances.Model;

namespace ZooFinances.Preserver
{
    public class Giraffe : Animal
    {
        public static int count;

        public static string FoodType;

        public static double FoodPrice;

        public static double FoodRatePerDay;

        public Giraffe(LogbookModel model)
        {
            count++;
            FoodType = model.AnimalTypeTable.AsEnumerable().Where(p => p.AnimalType.Contains(Animal.Giraffe)).Select(p => p.FoodType).FirstOrDefault();
            FoodPrice = Food.GetFoodPrice(model, FoodType);
            FoodRatePerDay = model.AnimalTypeTable.AsEnumerable().Where(p => p.AnimalType.Contains(Animal.Giraffe)).Select(p => p.FoodRatePerDay).FirstOrDefault();
        }
    }
}
