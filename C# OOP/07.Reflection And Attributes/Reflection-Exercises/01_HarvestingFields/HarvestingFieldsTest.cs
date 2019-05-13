 namespace P01_HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            var classType = typeof(HarvestingFields);

            var input = Console.ReadLine();
            while (input!= "HARVEST")
            {
                FieldInfo[] fields = null;

                if (input=="all")
                {
                    fields= classType.GetFields(BindingFlags.Instance | BindingFlags.Public 
                        | BindingFlags.NonPublic | BindingFlags.Static);

                }

                else  if (input=="protected")
                {
                    fields = classType.GetFields(BindingFlags.Instance 
                        | BindingFlags.NonPublic ).Where(f=>f.IsFamily).ToArray();
                }

                else if (input == "private")
                {
                    fields = classType.GetFields(BindingFlags.Instance
                        | BindingFlags.NonPublic).Where(f => f.IsPrivate).ToArray();
                }

                else if (input == "public")
                {
                    fields = classType.GetFields(BindingFlags.Instance
                        | BindingFlags.Public).ToArray();
                }

                foreach (var field in fields)
                {
                    string accessModifier = field.IsFamily ? "protected" : field.Attributes.ToString().ToLower();
                    Console.WriteLine($"{accessModifier} {field.FieldType.Name} {field.Name}");
                }
                
                input = Console.ReadLine();
            }
        }
    }
}
