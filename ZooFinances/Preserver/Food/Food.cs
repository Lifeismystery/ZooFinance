using System.Linq;
using ZooFinances.Model;

namespace ZooFinances.Preserver
{
    public class Food
    {
        public static string Meat = "Meat";

        public static string Fish = "Fish";

        public static string Plant = "Plant";

        public static double GetFoodPrice(LogbookModel model, string foodType)
        {
            return (double)model.FoodPriceTable.AsEnumerable().Where(p => p.FoodType.Contains(foodType)).Select(p => p.FoodPrice).FirstOrDefault();
        }
    }
}
