using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class HarvestingFieldsTests
{
    static void Main(string[] args)
    {
        var type = typeof(HarvestingFields);
        var allFields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
        var accessModifier = Console.ReadLine();

        while (accessModifier != "HARVEST")
        {
            PrintField(accessModifier, allFields);
            accessModifier = Console.ReadLine();
        }
    }

    private static void PrintField(string accessModifier, FieldInfo[] allFields)
    {
        switch (accessModifier)
        {
            case "private":
                foreach (var field in allFields.Where(x => x.IsPrivate))
                {
                    Console.WriteLine(GetFieldInfo(field));
                }
                break;
            case "public":
                foreach (var field in allFields.Where(x => x.IsPublic))
                {
                    Console.WriteLine(GetFieldInfo(field));
                }
                break;
            case "protected":
                foreach (var field in allFields.Where(x => x.IsFamily))
                {
                    Console.WriteLine(GetFieldInfo(field));
                }
                break;
            case "all":
                foreach (var field in allFields)
                {
                    Console.WriteLine(GetFieldInfo(field));
                }
                break;
            default:
                break;
        }
    }

    private static string GetFieldInfo(FieldInfo field)
    {
        var accessModifier = field.Attributes.ToString().ToLower();

        if(accessModifier == "family")
        {
            accessModifier = "protected";
        }
         return $"{accessModifier} {field.FieldType.Name} {field.Name}";
    }
}
