namespace _02_Collection
{
    using System;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().ToArray();

            ListyIterator<string> listyIterator = null;
            while (input[0] != "END")
            {
                if (input[0] == "Create")
                {
                    listyIterator = new ListyIterator<string>(input.Skip(1).ToList());
                }

                else if (input[0] == "Move")
                {
                    Console.WriteLine(listyIterator.Move());
                }

                else if (input[0] == "Print")
                {
                    Console.WriteLine(listyIterator.Print());
                }

                else if (input[0] == "HasNext")
                {
                    Console.WriteLine(listyIterator.HasNext());
                }

                else if (input[0] == "PrintAll")
                {
                    //foreach (var item in listyIterator)
                    //{
                    //    Console.Write($"{item} ");
                    //}
                    //Console.WriteLine();

                    Console.WriteLine(string.Join(" ",listyIterator));
                }

                input = Console.ReadLine().Split().ToArray();
            }
        }
    }
}
