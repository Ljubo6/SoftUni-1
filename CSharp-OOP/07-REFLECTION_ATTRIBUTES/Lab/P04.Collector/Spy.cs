using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string CollectGettersAndSetters(string className)
    {
        var classInfo = new StringBuilder();
        var classType = Type.GetType(className);

        if (classType != null)
        {
            var allMethods = classType.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
            
            foreach (var method in allMethods.Where(x => x.Name.StartsWith("get")))
            {
                classInfo.AppendLine($"{method.Name} will return {method.ReturnType}");
            }

            foreach (var method in allMethods.Where(x => x.Name.StartsWith("set")))
            {
                classInfo.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
            }
        }
        return classInfo.ToString().TrimEnd();
    }
}
