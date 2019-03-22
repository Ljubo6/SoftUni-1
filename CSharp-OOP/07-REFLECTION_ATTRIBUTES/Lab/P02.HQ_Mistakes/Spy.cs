using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string AnalyzeAcessModifiers(string className)
    {
        var classInfo = new StringBuilder();

        var classType = Type.GetType(className);

        if (classType != null)
        {
            var publicFields = classType.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);
            var publicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            var nonPublicMethods = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var publicField in publicFields)
            {
                classInfo.AppendLine($"{publicField.Name} must be private!");
            }

            foreach (var nonPublicMethod in nonPublicMethods.Where(x => x.Name.StartsWith("get")))
            {
                classInfo.AppendLine($"{nonPublicMethod.Name} have to be public!");
            }

            foreach (var publicMethod in publicMethods.Where(x => x.Name.StartsWith("set")))
            {
                classInfo.AppendLine($"{publicMethod.Name} have to be private!");
            }

        }
        return classInfo.ToString().TrimEnd();
    }
}
