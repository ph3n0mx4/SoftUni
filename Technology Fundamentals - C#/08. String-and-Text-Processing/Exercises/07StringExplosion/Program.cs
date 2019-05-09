using System;

namespace _07StringExplosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int strengthAdd = 0;
            for (int i = 0; i < text.Length; i++)
            {
                int strength = 0;
                if(text[i]=='>' && char.IsDigit(text[i + 1]) && text[i+1]>'0')
                {
                    strength = int.Parse(text[i + 1].ToString())+strengthAdd;
                }
                else
                {
                    continue;
                }

                int nextIndex = text.IndexOf('>', i + 1);

                if(nextIndex==-1)
                {
                    if (i + strength >= text.Length)
                    {
                        strength = text.Length - 1 - i;
                    }
                    text = text.Remove(i + 1, strength);
                    break;
                }

                else
                {
                    int count = nextIndex - i;
                    if(count >strength)
                    {
                        
                        text= text.Remove(i + 1, strength);
                    }

                    else
                    {
                        text =text.Remove(i + 1, count-1);
                        strengthAdd = strength - count + 1;
                    }
                }

                i = 0;
            }

            Console.WriteLine(text);
        }
    }
}
