using System;
using System.Text.RegularExpressions;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string regexArtist = @"^([\ \t]*[A-Z][a-z\ \']+)$";
            string regexSong = @"^[A-Z ]+$";

            string input = "";

            while((input=Console.ReadLine())!="end")
            {
                string[] currentInput = input.Split(":",StringSplitOptions.RemoveEmptyEntries);
                string artist = currentInput[0].ToString();
                string song = currentInput[1].ToString();

                Match matchA = Regex.Match(artist, regexArtist);
                Match matchS = Regex.Match(song, regexSong);

                if(!matchA.Success || !matchS.Success)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                int key = artist.Length;
                string w = string.Join(":", currentInput);
                string crypted = "";
                for (int i = 0; i < w.Length; i++)
                {
                    char symbol = w[i];

                    if(symbol==':')
                    {
                        crypted += '@';
                        continue;
                    }

                    if(symbol==' ' || symbol=='\''|| symbol == '\t')
                    {
                        crypted += symbol;
                        continue;
                    }

                    char newSymbol = (char)(symbol + key);
                    
                    if(newSymbol>'z' && (symbol >= 'a' && symbol <= 'z'))
                    {
                        int aa = newSymbol - (int)'z';
                        int cKey = aa;
                        newSymbol = (char)('a'+cKey-1);
                        crypted += newSymbol;
                    }

                    else if(newSymbol>'Z'&& (symbol>='A'&& symbol<='Z'))
                    {
                        int aa = newSymbol - (int)'Z';
                        int cKey = aa;
                        newSymbol = (char)('A' + cKey-1);
                        crypted += newSymbol;
                    }

                    else
                    {
                        crypted += newSymbol;
                    }
                }

                Console.WriteLine($"Successful encryption: {crypted}");
            }
        }
    }
}
