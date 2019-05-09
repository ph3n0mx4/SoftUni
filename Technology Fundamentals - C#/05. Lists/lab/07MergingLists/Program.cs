using System;
using System.Collections.Generic;
using System.Linq;
namespace _07MergingLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> listOne = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> listTwo = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> listAll = new List<int>();

            if (listOne.Count==listTwo.Count)
            {
                for (int i = 0; i < listOne.Count; i++)
                {
                    listAll.Add(listOne[i]);
                    listAll.Add(listTwo[i]);
                }
            }

            else if (listOne.Count >= listTwo.Count)
            {
                for (int i = 0; i < listTwo.Count; i++)
                {
                    listAll.Add(listOne[i]);
                    listAll.Add(listTwo[i]);
                }

                for (int i = listTwo.Count; i < listOne.Count; i++)
                {
                    listAll.Add(listOne[i]);
                }
            }

            else if (listOne.Count <= listTwo.Count)
            {
                for (int i = 0; i < listOne.Count; i++)
                {
                    listAll.Add(listOne[i]);
                    listAll.Add(listTwo[i]);
                }

                for (int i = listOne.Count; i < listTwo.Count; i++)
                {
                    listAll.Add(listTwo[i]);
                }
            }

            Console.WriteLine(string.Join(' ',listAll));
        }
    }
}
