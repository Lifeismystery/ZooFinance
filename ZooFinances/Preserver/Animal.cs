using System;
using System.Windows.Forms;

namespace ZooFinances.Preserver
{
    public class Animal
    {
        public static Animal unknowAnimal;
        public static Animal Error(string animal)
        {
            MessageBox.Show("No animalType for " + animal);
            return unknowAnimal;
        }
    }
}