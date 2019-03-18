using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Fix_Emails
{
    class Program
    {
        static void Main(string[] args)
        {
            var emailbook = new Dictionary<string, string>();

            while (true)
            {
                string name = Console.ReadLine();

                if (name == "stop")
                {
                    break;
                }
                else
                {
                    string email = Console.ReadLine().ToLower();
                    if (emailbook.ContainsKey(name))
                    {
                        emailbook[name] = email;
                    }
                    else
                    {
                        emailbook.Add(name, email);
                    }
                }
            }

            var newEmailbook = new Dictionary<string, string>();

            foreach (var kvp in emailbook)
            {
                string emailToConfirm = kvp.Value;
                if (!emailToConfirm.EndsWith("uk") && 
                    !emailToConfirm.EndsWith("us"))
                {
                    newEmailbook[kvp.Key] = kvp.Value;
                }
            }
            foreach (var kvp in newEmailbook)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
