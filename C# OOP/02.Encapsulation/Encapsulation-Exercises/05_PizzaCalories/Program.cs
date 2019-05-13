namespace _05_PizzaCalories
{
    using System;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var pizzaName = Console.ReadLine().Split().ToArray();
                var cmdDough = Console.ReadLine().Split().ToArray();
                string flour = cmdDough[1];
                string technique = cmdDough[2];
                double weightDough = double.Parse(cmdDough[3]);
                var dough = new Dough(weightDough, flour, technique);
                var pizza = new Pizza(pizzaName[1],dough);

                var cmdTopping = Console.ReadLine().Split().ToArray();
                while (cmdTopping[0]!="END")
                {
                    double weightTooping = double.Parse(cmdTopping[2]);
                    string type = cmdTopping[1];
                    var topping = new Topping(type, weightTooping);
                    pizza.AddTopping(topping);

                    cmdTopping = Console.ReadLine().Split().ToArray();
                }

                Console.WriteLine($"{pizza.Name} - {pizza.GetTotalCalories():f2} Calories.");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
