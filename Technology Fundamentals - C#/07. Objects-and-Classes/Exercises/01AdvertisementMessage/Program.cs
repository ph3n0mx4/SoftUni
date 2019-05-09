using System;

namespace _01AdvertisementMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            var phrases = new string[]
            {
                "Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can’t live without this product."
            };

            var events = new string[]
            {
                "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!"
            };

            var autors = new string[]
            {
                "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva"
            };

            var cities = new string[]
            {
                "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse"
            };

            int n = int.Parse(Console.ReadLine());
            Random rnd = new Random();

            for (int i = 0; i < n; i++)
            {
                string first =phrases[rnd.Next(0,phrases.Length)];
                string second =events[rnd.Next(0,events.Length)];
                string third =autors[rnd.Next(0,autors.Length)];
                string forth =cities[rnd.Next(0,cities.Length)];

                Console.WriteLine($"{first} {second} {third} – {forth}.");
            }

        }
    }
}
