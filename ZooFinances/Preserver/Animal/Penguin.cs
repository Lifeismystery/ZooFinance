using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooFinances.Model;
using ZooFinances.Preserver;

namespace ZooFinances.Preserver
{
    public class Penguin : Animal
    {
        public static int count;

        public static string FoodType;

        public static double FoodPrice;

        public static double FoodRatePerDay;

        public Penguin(LogbookModel model)
        {
            count++;
            FoodType = model.AnimalTypeTable.AsEnumerable().Where(p => p.AnimalType.Contains(Animal.Penguin)).Select(p => p.FoodType).FirstOrDefault();
            FoodPrice = Food.GetFoodPrice(model, FoodType);
            FoodRatePerDay = model.AnimalTypeTable.AsEnumerable().Where(p => p.AnimalType.Contains(Animal.Penguin)).Select(p => p.FoodRatePerDay).FirstOrDefault();
        }
    }
}
