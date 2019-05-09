using System;
using System.Collections.Generic;
using System.Linq;

namespace _09PokemonDon_tGo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            
            int sum = 0;

            while (nums.Count != 0)
            {
                int index = int.Parse(Console.ReadLine());

                if (index >= 0 && index < nums.Count)
                {
                    int intForRemove = nums[index];
                    sum += intForRemove;
                    nums.RemoveAt(index);

                    IncreaseDevcreaseSequence(nums, intForRemove);
                }

                else if (index < 0)
                {
                    int intForRemove = nums[0];
                    nums.RemoveAt(0);
                    int intForInsert = nums[nums.Count-1];
                    nums.Insert(0,intForInsert);
                    sum += intForRemove;

                    IncreaseDevcreaseSequence(nums, intForRemove);
                }

                else
                {
                    int intForRemove = nums[nums.Count - 1];

                    nums.RemoveAt(nums.Count - 1);
                    int intForInsert = nums[0];
                    nums.Add(intForInsert);
                    sum += intForRemove;

                    IncreaseDevcreaseSequence(nums, intForRemove);
                }

            }

            Console.WriteLine(sum);
        }

        public static void IncreaseDevcreaseSequence(List<int> nums, int intForRemove)
        {
            for (int i = 0; i < nums.Count; i++)
            {
                if (intForRemove >= nums[i])
                {
                    nums[i] += intForRemove;
                }

                else
                {
                    nums[i] -= intForRemove;
                }
            }
        }
    }
}
