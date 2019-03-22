using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string RevealPrivateMethods(string className)
    {
        var classInfo = new StringBuilder();

        var classType = Type.GetType(className);

        if (classType != null)
        {
            classInfo.AppendLine($"All Private Methods of Class: {className}");
            classInfo.AppendLine($"Base Class: {classType.BaseType.Name}");

            var nonPublicMethods = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
            
            foreach (var nonPublicMethod in nonPublicMethods)
            {
                classInfo.AppendLine(nonPublicMethod.Name);
            }
        }
        return classInfo.ToString().TrimEnd();
    }
}
