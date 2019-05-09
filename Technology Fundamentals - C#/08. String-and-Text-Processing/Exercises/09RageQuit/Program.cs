using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace _09RageQuit
{
    class Program
    {
        static void Main(string[] args)
        {
            string sequence = Console.ReadLine().ToUpper();
            var currentList = new List<char>();
            var resultList = new List<char>();
           
            for (int i = 0; i < sequence.Length; i++)
            {
                int num = 0;
                if (char.IsDigit(sequence[i]))
                {
                    if (i != sequence.Length - 1 && char.IsDigit(sequence[i + 1]))
                    {
                        string stringNum = sequence.Substring(i, 2);
                        num = int.Parse(stringNum);
                    }

                    else
                    {
                        num = int.Parse(sequence[i].ToString());
                    }

                    for (int x = 0; x < num; x++)
                    {
                        resultList.AddRange(currentList);
                    }

                    currentList.Clear();
                }
                
                else
                {
                    currentList.Add(sequence[i]);
                }
            }
            
            string output = string.Join("", resultList);
            
            Console.WriteLine($"Unique symbols used: {output.Distinct().Count()}");
            Console.WriteLine(output);

        }
    }
}