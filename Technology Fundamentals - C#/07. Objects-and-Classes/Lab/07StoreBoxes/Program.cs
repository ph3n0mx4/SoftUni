using System;
using System.Collections.Generic;
using System.Linq;

namespace _07StoreBoxes
{
    class Item
    {
        public string Name { get; set; }

        public double Price { get; set; }
    }

    class Box
    {
        public Box()
        {
            Item = new Item();
        }
        public string SerialNumber { get; set; }

        public Item Item { get; set; }

        public int Quantity { get; set; }

        public double PriceBox { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var data = Console.ReadLine().Split().ToArray();
            List <Box> boxList = new List<Box>();
            while(data[0]!= "end")
            {
                Box currentList = new Box();

                currentList.SerialNumber = data[0];
                currentList.Item.Name = data[1];
                currentList.Quantity = int.Parse(data[2]);
                currentList.Item.Price = double.Parse(data[3]);
                currentList.PriceBox = int.Parse(data[2]) * double.Parse(data[3]);

                boxList.Add(currentList);

                data = Console.ReadLine().Split().ToArray();
            }

            boxList = boxList.OrderBy(x => -x.PriceBox).ToList();

            foreach (var item in boxList)
            {
                Console.WriteLine(item.SerialNumber);
                Console.WriteLine($"-- {item.Item.Name} - ${item.Item.Price:f2}: {item.Quantity}");
                Console.WriteLine($"-- ${item.PriceBox:f2}");
            }
        }
    }
}
