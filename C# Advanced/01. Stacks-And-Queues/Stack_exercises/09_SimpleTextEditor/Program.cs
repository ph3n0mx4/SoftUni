using System;
using System.Collections.Generic;

namespace _09_SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string text = "";
            Stack<string> history = new Stack<string>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                switch (input[0])
                {
                    case "1":
                        string addSubstring = "add,";
                        addSubstring += input[1];

                        history.Push(addSubstring);

                        text+= input[1];
                        break;

                    case "2":
                        int length = int.Parse(input[1]);
                        int index = text.Length - length;

                        string delSubstring = "del,";
                        delSubstring += text.Substring(index);

                        history.Push(delSubstring);

                        text = text.Remove(index, length);
                        break;

                    case "3":
                        int retunIndex = int.Parse(input[1])-1;
                        string output = text[retunIndex].ToString();
                        Console.WriteLine(output);
                        break;
                    case "4":
                        string[] undoes = history.Pop().Split(",");

                        if(undoes[0]=="add")
                        {
                            string forDel = undoes[1];
                            int currentIndex = text.LastIndexOf(forDel);
                            int currentLength = forDel.Length;
                            text = text.Remove(currentIndex, currentLength);
                        }

                        else if (undoes[0]=="del")
                        {
                            string forAdd = undoes[1];
                            text += forAdd;
                        }

                        break;
                }
            }
        }
    }
}
