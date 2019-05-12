namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double nOfRectangle = double.Parse(nums[0]);
            double nOfInsectionChecks = double.Parse(nums[1]);

            var rectangles = new List<Rectangle>();
            for (double i = 0; i < nOfRectangle; i++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                //id, width, height and coordinates
                string id = input[0];
                double width = double.Parse(input[1]);
                double height = double.Parse(input[2]);
                double x = double.Parse(input[3]);
                double y = double.Parse(input[4]);

                Rectangle rectangle = new Rectangle(id, width, height, x, y);
                rectangles.Add(rectangle);
            }

            for (double i = 0; i < nOfInsectionChecks; i++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string id1 = input[0];
                string id2 = input[1];

                var rect1 = rectangles.Find(x => x.Id == id1);
                var rect2 = rectangles.Find(x => x.Id == id2);

                if(rect1.Checkdoubleersect(rect2))
                {
                    Console.WriteLine("true");
                }

                else
                {
                    Console.WriteLine("false");
                }
            }
        }
    }
}
