using System;
using System.Collections.Generic;
using System.Linq;

namespace _04Songs
{   class Song
    {
        public string TypeList { get; set; }

        public string Name { get; set; }

        public string Time { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var songs = new List<Song>();

            for (int i = 0; i < n; i++)
            {
                var data = Console.ReadLine().Split("_").ToArray();

                Song song = new Song();

                song.TypeList = data[0];
                song.Name = data[1];
                song.Time = data[2];

                songs.Add(song);
            }

            string typeList = Console.ReadLine();

            if (typeList == "all")
            {
                foreach (var item in songs)
                {
                    Console.WriteLine(item.Name);
                }
            }

            else
            {
                songs = songs.Where(x => x.TypeList == typeList).ToList();

                foreach(var item in songs)
                {
                    Console.WriteLine(item.Name);
                }
            }
            
        }
    }
}
