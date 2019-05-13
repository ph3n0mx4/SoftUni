using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string AnalyzeAcessModifiers(string className)
    {
        var classType = Type.GetType(className);

        var classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Public);
        var classPublicMethod = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
        var classNonPublicMethod = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        var sb = new StringBuilder();

        foreach (var field in classFields)
        {
            sb.AppendLine($"{field.Name} must be private!");
        }

        foreach (var method in classNonPublicMethod.Where(m => m.Name.StartsWith("get")))
        {
            sb.AppendLine($"{method.Name} have to be public!");
        }

        foreach (var method in classPublicMethod.Where(m=>m.Name.StartsWith("set")))
        {
            sb.AppendLine($"{method.Name} have to be private!");
        }
        return sb.ToString().Trim();
    }
}

