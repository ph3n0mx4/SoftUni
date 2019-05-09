namespace _01Dictionary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            string[] firstInput = Console.ReadLine().Split(" | ");
            var list = new Dictionary<string, List<string>>();
            for (int i = 0; i < firstInput.Length; i++)
            {
                string[] currentWord = firstInput[i].Split(": ");
                string word = currentWord[0].ToString();
                string definition = currentWord[1].ToString();

                if(!list.ContainsKey(word))
                {
                    list[word] = new List<string>();
                }
                list[word].Add(definition);
            }

            string[] secondInput = Console.ReadLine().Split(" | ");
            foreach (var word in secondInput)
            {
                foreach (var kvp in list)
                {
                    if(word!=kvp.Key)
                    {
                        continue;
                    }
                    Console.WriteLine($"{kvp.Key}");
                    foreach (var definition in kvp.Value.OrderByDescending(x=>x.Length))
                    {
                        Console.WriteLine($" -{definition}");
                    }
                }
            }
            string thirdInput = Console.ReadLine();
            if(thirdInput== "End")
            {
                return;
            }
            else if (thirdInput== "List")
            {
                foreach (var kvp in list.OrderBy(x=>x.Key))
                {
                    Console.Write(kvp.Key+" ");
                }
                Console.WriteLine();
            }

        }
    }
}
