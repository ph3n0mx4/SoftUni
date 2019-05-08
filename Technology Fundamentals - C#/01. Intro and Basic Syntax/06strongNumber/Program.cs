using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06strongNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputNum = Console.ReadLine();
            int strongNum = int.Parse(inputNum);
            int num = strongNum;
            int digit = strongNum;
            int sum = 0;

            for (int i = 0; i < inputNum.Length; i++)
            {
                digit = num % 10;
                num = num / 10;
                int num4 = digit;

                if(num4 == 0)
                {
                    num4 = 1;
                }

                else
                {
                    for (int j = 1; j < digit; j++)
                    {

                        num4 *= j;
                    }
                    
                }
                sum += num4;

            }
            if (sum==strongNum)
            {
                Console.WriteLine("yes");
            }

            else
            {
                Console.WriteLine("no");
                
            }
        }
    }
}
