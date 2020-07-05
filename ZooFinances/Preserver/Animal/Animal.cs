using System.Windows.Forms;

namespace ZooFinances.Preserver
{
    public class Animal
    {
        public static string Tiger = "Tiger";
        public static string Penguin = "Penguin";
        public static string Giraffe = "Giraffe";

        public static Animal unknowAnimal;
        public static Animal Error(string animal)
        {
            MessageBox.Show("No animalType for " + animal);
            return unknowAnimal;
        }
    }
}