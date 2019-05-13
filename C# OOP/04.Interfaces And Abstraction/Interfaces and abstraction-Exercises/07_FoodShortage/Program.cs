namespace _07_FoodShortage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var list = new List<Human>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split().ToArray();

                if(input.Length==3)
                {
                    var rebel = new Rebel(input[0],int.Parse(input[1]), input[2]);
                    list.Add(rebel);
                }

                else if (input.Length == 4)
                {
                    var citizen = new Citizen(input[0], int.Parse(input[1]), input[2], input[3]);
                    list.Add(citizen);
                }
            }

            var name = Console.ReadLine();
            while (name.ToLower()!="end")
            {
                if(list.Any(x=>x.Name==name))
                {
                    list.First(x => x.Name == name).BuyFood();
                }
                

                name = Console.ReadLine();
            }

            Console.WriteLine(list.Sum(s=>s.Food));
        }
    }
}
