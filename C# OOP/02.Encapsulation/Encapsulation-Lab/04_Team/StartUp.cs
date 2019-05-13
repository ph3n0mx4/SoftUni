namespace PersonsInfo
{
    using System;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Team team = new Team("SoftUni");
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(" ").ToArray();

                string firstName = input[0];
                string lastName = input[1];
                int age = int.Parse(input[0]);
                decimal salary = decimal.Parse(input[0]);

                var person = new Person(firstName, lastName, age, salary);

                team.AddPlayer(person);
            }

            var firstTeam = team.FirstTeam;
            var reserveTeam = team.ReserveTeam;

            Console.WriteLine($"First team has {firstTeam.Count} players.");
            Console.WriteLine($"Reserve team has  {reserveTeam.Count} players.");
        }
    }
}
