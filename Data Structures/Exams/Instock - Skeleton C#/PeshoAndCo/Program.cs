
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var list = new List<string>() { "1", "2", "3", "10", "20" };
        list.OrderBy(x => x);
        foreach (var item in list)
        {
            System.Console.WriteLine(item);
        }
    }
}

