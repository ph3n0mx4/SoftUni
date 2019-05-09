using System;

namespace _04PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            int a = CountOfCharacter6to10(password);
            int b = CheckOnlyLettersAndDigit(password);
            int c = CheckMinTwoDigit(password);
            
            if (a==0)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }

            if (b==0)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }

            if (c==0)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }

            if(a+b+c==3)
            {
                Console.WriteLine("Password is valid");
            }
        }

        public static int CountOfCharacter6to10(string pass)
        {
            int numberOfSymbol = pass.Length;
            if(numberOfSymbol>=6 && numberOfSymbol <= 10)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public static int CheckOnlyLettersAndDigit(string pass)
        {
            int validChar = 0;
            for (int i = 0; i < pass.Length; i++)
            {
                char symbol = pass[i];
                if((symbol >='a' && symbol<='z') || (symbol >= 'A' && symbol <= 'Z') || (symbol >= '0' && symbol <= '9'))
                {
                    validChar++;
                }
            }

            if(validChar==pass.Length)
            {
                return 1;
            }

            else
            {
                return 0;
            }

        }

        public static int CheckMinTwoDigit(string pass)
        {
            int count = 0;
            for (int i = 0; i < pass.Length; i++)
            {
                char symbol = pass[i];
                if (symbol >= '0' && symbol <= '9')
                {
                    count++;
                }
            }

            if(count>=2)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
