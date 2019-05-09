using System;
using System.Linq;

namespace _05MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine().TrimStart('0');
            int multiplier = int.Parse(Console.ReadLine());

            if(number=="0"||multiplier==0)
            {
                Console.WriteLine(0);
                return;
            }
            string @newResult = string.Empty;
            int onMind = 0;
            number = string.Join("", number.ToCharArray().Reverse());
            string result = string.Empty;
            for (int i = 0; i < number.Length; i++)
            {
                int digit = int.Parse(number[i].ToString());
                int multiply = digit * multiplier + onMind;
                result += multiply % 10;
                onMind = multiply / 10;

                if(i==number.Length-1 && onMind!=0)
                {
                    result += onMind;
                }
            }
            result = string.Join("", result.ToCharArray().Reverse());
            Console.WriteLine(result);
        }
    }
}
