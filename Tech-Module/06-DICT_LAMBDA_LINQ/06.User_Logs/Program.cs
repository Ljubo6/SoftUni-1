using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.User_Logs
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string[] input = Console.ReadLine()
               .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .ToArray();

                
                var logs = new Dictionary<string, Dictionary<string, int>>();

                if (input[0]!="end")
                {
                    char[] usernameArr = input[2].Skip(5).ToArray();
                    char[] ipArr = input[0].Skip(3).ToArray();
                    string username = new string(usernameArr);
                    string ip = new string(ipArr);

                    if (!logs.ContainsKey(username))
                    {
                        logs[username] = new Dictionary<string, int>();
                    }

                    if (!logs[username].ContainsKey(ip))
                    {
                        logs[username][ip] = 1;
                    }
                    else
                    {
                        logs[username][ip]++;
                    }
                }
                else
                {
                    foreach (var kvp in logs)
                    {
                        Console.WriteLine($"{logs.Keys}: {logs[username].Key} ");
                    }

                    
                    break;
                }
            }

           


        }
    }
}
