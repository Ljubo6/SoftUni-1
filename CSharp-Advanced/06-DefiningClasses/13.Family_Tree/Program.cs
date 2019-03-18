using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        List<Person> familyTree = new List<Person>();
        
        // Selecting information about the person to be found later.
        string[] personalInfoToLookFor = Console.ReadLine().Split();
        var personDoB = new DateTime();
        var personFirstName = string.Empty;
        var personLastName = string.Empty;
        if (personalInfoToLookFor.Length == 1)
        {
            personDoB = DateTime.Parse(personalInfoToLookFor[0]);
        }
        else if (personalInfoToLookFor.Length == 2)
        {
            personFirstName = personalInfoToLookFor[0];
            personLastName = personalInfoToLookFor[1];
        }

        //Building the family tree.
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "End")
            {
                break;
            }

            List<string> info = input.Split().ToList();
            if (info.Contains("-"))
            {
                info.RemoveAll(x => x == "-");

                if (info.Count == 2)
                {
                    var parentDoB = DateTime.Parse(info[0]);
                    var childDoB = DateTime.Parse(info[1]);
                    var currentParent = familyTree.FirstOrDefault(p => p.DoB == parentDoB);
                    var currentChild = familyTree.FirstOrDefault(p => p.DoB == childDoB);

                    if (currentParent == null)
                    {
                        currentParent = currentChild.Parents.FirstOrDefault(p => p.DoB == parentDoB);
                        if (currentParent == null)
                        {
                            var newPerson = new Person(null, null, parentDoB);
                            familyTree.Add(newPerson);
                        }
                        else
                        {
                            
                        }
                    }

                }
            }
        }
    }
}
