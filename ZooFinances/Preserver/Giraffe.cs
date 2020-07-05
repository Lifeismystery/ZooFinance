﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooFinances.Preserver;

namespace ZooFinances.Model
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
            FoodType = model.AnimalTypeTable.AsEnumerable().Where(p => p.AnimalType.Contains(AnimalType.Giraffe)).Select(p => p.FoodType).FirstOrDefault();
            FoodPrice = (double)model.FoodPriceTable.AsEnumerable().Where(p => p.FoodType.Contains(FoodType)).Select(p => p.FoodPrice).FirstOrDefault();
            FoodRatePerDay = model.AnimalTypeTable.AsEnumerable().Where(p => p.AnimalType.Contains(AnimalType.Giraffe)).Select(p => p.FoodRatePerDay).FirstOrDefault();
        }
        public static void ShowNumberOfObjects()
        {
            Console.WriteLine("Giraffe = {0}", Giraffe.count.ToString());
        }
    }
}
