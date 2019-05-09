using System;

namespace _10TopNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            bool resultOne = false;
            bool resultTwo = false;
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <=n; i++)
            {
                resultOne = DivisibleCheck(i);
                resultTwo = LeastOneOddDigit(i);

                if (resultOne == true && resultTwo == true)
                {
                    Console.WriteLine(i);
                }
            }
        }

        public static bool DivisibleCheck(int number)
        {
            bool result = false;
            int sum = 0;
            while(number!=0)
            {
                int digit = number % 10;
                number /= 10;
                sum += digit;
            }
            if(sum%8==0)
            {
                result = true;
            }
            return result;
        }

        public static bool LeastOneOddDigit(int number)
        {
            bool result = false;
            while (true)
            {
                int digit = number % 10;
                if(digit%2==1)
                {
                    result = true;
                    break;
                }
                else if (number==0)
                {
                    break;
                }
                number /= 10;
                
            }

            return result;
        }

    }
}
