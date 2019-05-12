namespace _03_Stack
{
    using System;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] {' ',',' },StringSplitOptions.RemoveEmptyEntries).ToArray();
            var list = new StackIterator<string>();
            while (input[0]!="END")
            {
                if(input[0]=="Push")
                {
                    var elements = input.Skip(1).ToArray();
                    //elements = elements.Reverse().ToArray();

                    if(list.Count()!=0)
                    {
                        list.Push(elements);
                        //foreach (var item in list)
                        //{
                        //    Console.WriteLine(item);
                        //}
                    }

                    else
                    {
                        list.Push(elements);
                    }
                }

                else
                {
                    if(list.Count()==0)
                    {
                        Console.WriteLine("No elements");
                    }

                    else
                    {
                        list.Pop();
                    }
                }
                input = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
