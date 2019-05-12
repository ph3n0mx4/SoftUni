namespace DefiningClasses
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            DateTime firstDate = DateTime.Parse(Console.ReadLine());
            DateTime secondDate = DateTime.Parse(Console.ReadLine());

            var dateModifier = new DateModifier(firstDate, secondDate);

            var difference = dateModifier.DifferentDays();
            Console.WriteLine(difference);
        }
    }
}
