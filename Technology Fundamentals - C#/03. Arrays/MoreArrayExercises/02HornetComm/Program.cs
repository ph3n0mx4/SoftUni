using System;
using System.Collections.Generic;
using System.Linq;

namespace _02HornetComm
{
    class Program
    {
        public static void Main(string[] args)
        {
            string[] cmd = Console.ReadLine().Split(new string[] { " <-> " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            List<string> broadcastsList = new List<string>();
            List<string> messageList = new List<string>();
            while (cmd[0] != "Hornet is Green")
            {
                if(cmd.Length==1)
                {
                    cmd = Console.ReadLine().Split(new string[] { " <-> " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    continue;
                }
                
                string firstQuery = cmd[0];
                string secondQuery = cmd[1];
                bool checkFirstForDigit = true;
                for (int i = 0; i < firstQuery.Length; i++)
                {
                    char symbol = firstQuery[i];
                    if (symbol < 48 || symbol > 57)
                    {
                        checkFirstForDigit = false;
                        break;
                    }
                }
                bool checkSecondForDigitAndLetter = true;
                for (int i = 0; i < secondQuery.Length; i++)
                {
                    char symbol = secondQuery[i];
                    if(symbol < 48 || (symbol >57 && symbol <65) || (symbol > 90 && symbol <97) || symbol>122)
                    {
                        checkSecondForDigitAndLetter = false;
                        break;
                    }
                }

                if(!checkSecondForDigitAndLetter)
                {
                    //Console.WriteLine("error");
                    cmd = Console.ReadLine().Split(new string[] { " <-> " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    continue;
                }
                else if(checkFirstForDigit && checkSecondForDigitAndLetter)
                {
                    string recipient = string.Empty;
                    string message = secondQuery;

                    for (int i = firstQuery.Length-1; i >= 0; i--)
                    {
                        recipient += firstQuery[i];
                    }
                    string result = recipient + " " + "->" + " " + message;
                    messageList.Add(result);
                    //Console.WriteLine("message");
                    //private message
                }

                else if(!checkFirstForDigit && checkSecondForDigitAndLetter)
                {
                    string frequency = string.Empty;
                    string message = firstQuery;

                    for (int i = 0; i < secondQuery.Length; i++)
                    {
                        string symbol = secondQuery[i].ToString();
                        if(symbol==symbol.ToUpper())
                        {
                            symbol=symbol.ToLower();
                            frequency += symbol;
                        }

                        else
                        {
                            symbol=symbol.ToUpper();
                            frequency += symbol;
                        }
                    }

                    string result = frequency + " " + "->" + " " + message;
                    broadcastsList.Add(result);
                    //Console.WriteLine("broadcasts");
                    //broadcasts
                }

                cmd = Console.ReadLine().Split(new string[] { " <-> " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            if(broadcastsList.Count==0)
            {
                broadcastsList.Add("None");
            }
            if (messageList.Count == 0)
            {
                messageList.Add("None");
            }

            Console.WriteLine("Broadcasts:");
            Console.WriteLine(string.Join("\n",broadcastsList));
            Console.WriteLine("Messages:");
            Console.WriteLine(string.Join("\n",messageList));
        }
    }
}   
