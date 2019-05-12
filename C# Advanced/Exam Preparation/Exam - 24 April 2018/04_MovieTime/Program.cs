using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_MovieTime
{
    class Program
    {
        static void Main(string[] args)
        {
            string genre = Console.ReadLine();
            string duration = Console.ReadLine();

            var list = new Dictionary<string, Dictionary<string, string>>();

            var input = Console.ReadLine().Split("|",StringSplitOptions.RemoveEmptyEntries).ToArray();
            while (input[0]!= "POPCORN!")
            {
                string name = input[0];
                string currentGenre = input[1];
                string time = input[2];
                //time = time
                if(!list.ContainsKey(currentGenre))
                {
                    list[currentGenre] = new Dictionary<string, string>();
                }

                list[currentGenre][name] = time;
                input = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            var result = list.OrderBy(x => x).First(x => x.Key == genre).Value.ToDictionary(x => x.Key, x => x.Value);

            if (duration=="Short")
            {
                result = result.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            }

            else if (duration=="Long")
            {
                result = result.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            }

            var queue = new Queue<string>(result.Keys);
            
            //foreach (var item in result)
            //{
            //    queue.Enqueue(item.Key);
            //}
            while (true)
            {
                Console.WriteLine(queue.Peek());
                var cmd = Console.ReadLine();

                if(cmd=="Yes")
                {
                    break;
                }

                else
                {
                    queue.Dequeue();
                }
            }
            string theMovie = queue.Dequeue();
            Console.WriteLine($"We're watching {theMovie} - {result.First(x=>x.Key== theMovie).Value}");

            var totalDuration = TimeSpan.Parse("00:00:00");
            foreach (var kvp in list)
            {
                foreach (var item in kvp.Value)
                {
                    DateTime currentTime = DateTime.Parse(item.Value);
                    totalDuration = totalDuration.Add(currentTime.TimeOfDay);
                }
            }
            Console.WriteLine($"Total Playlist Duration: {totalDuration}");
        }
    }
}
