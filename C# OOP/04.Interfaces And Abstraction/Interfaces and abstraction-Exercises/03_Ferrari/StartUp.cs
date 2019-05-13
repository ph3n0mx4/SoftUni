namespace _03_Ferrari
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            string driversName = Console.ReadLine();
            ICar ferrari = new Ferrari(driversName);
            Console.WriteLine(ferrari);
        }
    }
}
