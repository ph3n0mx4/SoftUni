using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        var classType = typeof(StartUp);

        var methods = classType.GetMethods(
            BindingFlags.Instance |
            BindingFlags.Public |
            BindingFlags.Static);

        foreach (var method in methods)
        {
            if(method.CustomAttributes.Any(a=>a.AttributeType==typeof(AuthorAttribute)))
            {
                var attributes = method.GetCustomAttributes(false);

                foreach (AuthorAttribute attr in attributes)
                {
                    Console.WriteLine($"{method.Name} is written by {attr.Name}");
                }
            }
        }
    }
}

