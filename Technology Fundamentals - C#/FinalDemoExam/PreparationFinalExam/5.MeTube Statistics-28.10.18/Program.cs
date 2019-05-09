using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.MeTube_Statistics_28._10._18
{
    class Statistic
    {
        public int Views { get; set; }

        public int Likes { get; set; }

        public Statistic()
        {
            Views = 0;
            Likes = 0;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new char[] { ':', '-' }, StringSplitOptions.RemoveEmptyEntries);
            var listVideos = new Dictionary<string, Statistic>();
            while (input[0]!= "stats time")
            {
                if(input[0]!="like" && input[0] != "dislike")
                {
                    string video = input[0];
                    int views = int.Parse(input[1]);
                    if(!listVideos.ContainsKey(video))
                    {
                        listVideos[video] = new Statistic();
                    }

                    listVideos[video].Views += views;
                }

                else if (listVideos.ContainsKey(input[1]) && (input[0] == "like" || input[0] == "dislike"))
                {
                    switch (input[0])
                    {
                        case "like":
                            listVideos[input[1]].Likes++;
                            break;

                        case "dislike":
                            listVideos[input[1]].Likes--;
                            break;
                    }
                }

                input = Console.ReadLine().Split(new char[] { ':', '-' }, StringSplitOptions.RemoveEmptyEntries);
            }

            string order = Console.ReadLine();
            switch(order)
            {
                case "by views":
                    foreach (var kvp in listVideos.OrderByDescending(x=>x.Value.Views))
                    {
                        Console.WriteLine($"{kvp.Key} - {kvp.Value.Views} views - {kvp.Value.Likes} likes");
                    }
                    break;
                case "by likes":
                    foreach (var kvp in listVideos.OrderByDescending(x => x.Value.Likes))
                    {
                        Console.WriteLine($"{kvp.Key} - {kvp.Value.Views} views - {kvp.Value.Likes} likes");
                    }
                    break;
            }
        }
    }
}
