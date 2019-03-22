using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        var callingMethodType = Assembly.GetCallingAssembly().EntryPoint.DeclaringType;
        var methods = callingMethodType.GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic);

        foreach (var method in methods)
        {
            var methodAttributes = method.GetCustomAttributes(false);
            foreach (var attribute in methodAttributes)
            {
                if (attribute is AuthorAttribute authorAttribute)
                {
                    Console.WriteLine($"{method.Name} is written by {authorAttribute.Name}");
                }
            }
        }
    }
}
