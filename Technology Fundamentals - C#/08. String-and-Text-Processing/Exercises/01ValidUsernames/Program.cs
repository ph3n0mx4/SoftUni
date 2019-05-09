using System;

namespace _01ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var username in usernames)
            {
                bool print = true;

                if(username.Length >=3 && username.Length<=16)
                {
                    for (int i = 0; i < username.Length; i++)
                    {
                        if (char.IsDigit(username[i]))
                        {
                            continue;
                        }

                        else if(char.IsLetter(username[i]))
                        {
                            continue;
                        }

                        else if(username[i]=='-' || username[i]=='_' )
                        {
                            continue;
                        }

                        else
                        {
                            print = false;
                            break;
                        }
                    }
                }

                else
                {
                    print = false;
                }

                if(print)
                {
                    Console.WriteLine(username);
                }

                print = true;
            }
        }
    }
}
