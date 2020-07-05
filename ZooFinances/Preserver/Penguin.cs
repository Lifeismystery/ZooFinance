using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooFinances.Preserver;

namespace ZooFinances.Model
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
            FoodType = model.AnimalTypeTable.AsEnumerable().Where(p => p.AnimalType.Contains(AnimalType.Penguin)).Select(p => p.FoodType).FirstOrDefault();
            FoodPrice = (double)model.FoodPriceTable.AsEnumerable().Where(p => p.FoodType.Contains(FoodType)).Select(p => p.FoodPrice).FirstOrDefault();
            FoodRatePerDay = model.AnimalTypeTable.AsEnumerable().Where(p => p.AnimalType.Contains(AnimalType.Penguin)).Select(p => p.FoodRatePerDay).FirstOrDefault();
        }
        public static void ShowNumberOfObjects()
        {
            Console.WriteLine("Penguin = {0}", Penguin.count.ToString());
        }
    }
}
