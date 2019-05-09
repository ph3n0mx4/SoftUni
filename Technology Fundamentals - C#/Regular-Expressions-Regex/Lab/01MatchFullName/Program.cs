using System;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;


namespace _01MatchFullName
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";
            string names = Console.ReadLine();

            MatchCollection matchesName = Regex.Matches(names, regex);

            foreach (Match name in matchesName)
            {
                Console.Write(name.Value +" ");
            }
        }
    }
}
