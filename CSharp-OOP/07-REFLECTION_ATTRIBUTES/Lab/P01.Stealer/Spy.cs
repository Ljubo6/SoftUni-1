using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

public class Spy
{
    public string StealFieldInfo(string classToInvestigate, params string[] fieldsToReveal)
    {
        var fieldInfo = new StringBuilder();

        var classType = Type.GetType(classToInvestigate);

        if (classType != null)
        {
            fieldInfo.AppendLine($"Class under investigation: {classToInvestigate}");

            var instance = Activator.CreateInstance(classType, new object[0]);

            var classFields = classType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            foreach (var field in classFields)
            {
                for (int i = 0; i < fieldsToReveal.Length; i++)
                {
                    if (fieldsToReveal[i] == field.Name)
                    {
                        fieldInfo.AppendLine($"{field.Name} = {field.GetValue(instance)}");
                    }
                }
            }
        }
        return fieldInfo.ToString().TrimEnd();
    }
}
