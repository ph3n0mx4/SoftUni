namespace _04_Telephony
{
    using System;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            var phoneNumbers = Console.ReadLine().Split().ToArray();
            var websites = Console.ReadLine().Split().ToArray();
            ICalling calling = new SmartPhone();
            IBrowsing browsing = new SmartPhone();

            foreach (var number in phoneNumbers)
            {
                try
                {
                    Console.WriteLine(calling.Call(number));
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }

            }

            foreach (var web in websites)
            {
                try
                {
                    Console.WriteLine(browsing.Browse(web));
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}
