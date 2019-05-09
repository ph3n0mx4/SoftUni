using System;
using System.Linq;

namespace _11ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                 .Select(int.Parse)
                                 .ToArray();
            string[] command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while(command[0]!="end")
            {
                if (command[0] == "exchange")
                {
                    long number = long.Parse(command[1]);
                    if(number<array.Length && number>=0)
                    {
                        
                        Exchange(number, array);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                    
                }

                else if (command[0] == "max" || command[0] == "min")
                {
                    if(command[0] == "max")
                    {
                        MaxOddOrMaxEven(command[1], array);
                    }

                    else if (command[0] == "min")
                    {
                        MinOddOrMinEven(command[1], array);
                    }
                }

                else if (command[0] == "first" || command[0] == "last")
                {
                    int count = int.Parse(command[1]);
                    if(count>array.Length || count < 0)
                    {
                        Console.WriteLine("Invalid count");
                    }
                    else
                    {
                        if (command[0] == "first")
                        {
                            FirstOddOrFirstEven(command[1], command[2], array);
                        }

                        else if (command[0] == "last")
                        {
                            LastOddOrLastEven(command[1], command[2], array);
                        }
                    }
                }

                command = Console.ReadLine().Split();
            }

            Console.WriteLine($"[{string.Join(", ", array)}]");
        }

        public static void Exchange(long number, int[] array)
        {
            for (int i = 0; i <= number; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    int firstNum = array[j];
                    int indexOfReverseCell = j + 1;
                    array[j] = array[indexOfReverseCell];
                    array[indexOfReverseCell] = firstNum;
                }
            }
        }

        public static void MaxOddOrMaxEven(string type, int[] arr)
        {
            int index = -1;
            int maxNumber = int.MinValue;
            if(type=="odd")
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if(arr[i]>=maxNumber && arr[i]%2==1)
                    {
                        index = i;
                        maxNumber = arr[i];
                    }
                }
            }
            else if(type == "even")
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] >= maxNumber && arr[i] % 2 == 0)
                    {
                        index = i;
                        maxNumber = arr[i];
                    }
                }
            }
            if(index == -1 )
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(index);
            }
            
        }

        public static void MinOddOrMinEven(string type, int[] arr)
        {
            int index = -1;
            int minNumber = int.MaxValue;
            if (type == "odd")
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] <= minNumber && arr[i] % 2 == 1)
                    {
                        index = i;
                        minNumber = arr[i];
                    }
                }
            }
            else if (type == "even")
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] <= minNumber && arr[i] % 2 == 0)
                    {
                        index = i;
                        minNumber = arr[i];
                    }
                }
            }

            if (index == -1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(index);
            }
        }

        public static void FirstOddOrFirstEven(string count,string type, int[] arr)
        {
            int num = int.Parse(count);
            int i = 0;
            int[] arrayFirstNums = new int[num];

            if (type=="odd")
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    if(arr[j] % 2 == 1)
                    {
                        arrayFirstNums[i] = arr[j];
                        i++;
                    }

                    if(i >= num)
                    {
                        break;
                    }
                }
            }
            else if(type == "even")
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    if (arr[j] % 2 == 0)
                    {
                        arrayFirstNums[i] = arr[j];
                        i++;
                    }

                    if (i >= num)
                    {
                        break;
                    }
                }
            }

            PrintFirstLast(i, arrayFirstNums);
        }

        public static void LastOddOrLastEven(string count, string type, int[] arr)
        {
            int num = int.Parse(count);
            int i = 0;
            int[] arrayFirstNums = new int[num];

            if (type == "odd")
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    if (arr[j] % 2 == 1)
                    {
                        arrayFirstNums[i] = arr[j];
                        i++;
                    }

                    if (i >= num)
                    {
                        break;
                    }
                }
            }
            else if (type == "even")
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    if (arr[j] % 2 == 0)
                    {
                        arrayFirstNums[i] = arr[j];
                        i++;
                    }

                    if (i >= num)
                    {
                        break;
                    }
                }
            }

            PrintFirstLast(i, arrayFirstNums);
        }

        public static void PrintFirstLast(int i, int[] arrayFirstNums)
        {
            if (i == 0)
            { Console.WriteLine("[]"); }
            else
            {
                int[] resultArr = new int[i];
                for (int x = 0; x < i; x++)
                {
                    resultArr[x] = arrayFirstNums[x];
                }

                Console.WriteLine($"[{string.Join(", ", resultArr)}]");
            }
        }
    }
}
