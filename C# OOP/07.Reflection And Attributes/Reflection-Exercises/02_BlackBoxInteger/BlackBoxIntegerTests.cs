namespace P02_BlackBoxInteger
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            var type = typeof(BlackBoxInteger);
            var instace = Activator.CreateInstance(type,true);
            var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            var input = Console.ReadLine().Split("_").ToArray();

            while (input[0] !="END")
            {
                string methodName = input[0];
                int value = int.Parse(input[1]);

                var method = methods.First(f => f.Name == methodName);
                method.Invoke(instace, new object[] { value });

                var field = type.GetField("innerValue", BindingFlags.Instance | BindingFlags.NonPublic);

                Console.WriteLine(field.GetValue(instace));
                input = Console.ReadLine().Split("_").ToArray();
            }
        }
    }
}
