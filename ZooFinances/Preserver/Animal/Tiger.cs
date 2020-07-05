using System.Linq;
using ZooFinances.Model;

namespace ZooFinances.Preserver
{
    public class Tiger : Animal
    {
        public static int count;

        public static string FoodType;

        public static double FoodPrice;

        public static double FoodRatePerDay;

        public Tiger(LogbookModel model)
        {
            count++;
            FoodType = model.AnimalTypeTable.AsEnumerable().Where(p => p.AnimalType.Contains(Animal.Tiger)).Select(p => p.FoodType).FirstOrDefault();
            FoodPrice = Food.GetFoodPrice(model, FoodType);
            FoodRatePerDay = model.AnimalTypeTable.AsEnumerable().Where(p => p.AnimalType.Contains(Animal.Tiger)).Select(p => p.FoodRatePerDay).FirstOrDefault();
        }
    }
}
