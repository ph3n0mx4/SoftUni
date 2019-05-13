using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string investigatedClass, params string[] requestedField)
    {
        string className = investigatedClass;

        Type classType = Type.GetType(className);

        var fieldClass = classType.GetFields(
            BindingFlags.Public |
            BindingFlags.Static |
            BindingFlags.Instance |
            BindingFlags.NonPublic);
        var classInstance = Activator.CreateInstance(classType, new object[] { });

        var sb = new StringBuilder();
        sb.AppendLine($"Class under investigation: {investigatedClass}");

        foreach (var field in fieldClass.Where(f=>requestedField.Contains(f.Name)))
        {
            sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }

        return sb.ToString().Trim();
    }
}

