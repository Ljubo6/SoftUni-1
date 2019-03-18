using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.TrainersSalary
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            int jelevCounter = 0;
            int royalCounter = 0;
            int roliCounter = 0;
            int trofonCounter = 0;
            int sinoCounter = 0;
            int guestsCounter = 0;

            
            for (int i = 0; i < n; i++)
            {
                string lecturer = Console.ReadLine().ToLower();
                if (lecturer == "jelev") { jelevCounter++; }
                if (lecturer == "royal") { royalCounter++; }
                if (lecturer == "roli") { roliCounter++; }
                if (lecturer == "trofon") { trofonCounter++; }
                if (lecturer == "sino") { sinoCounter++; }
                else { guestsCounter++; }
            }

            double jelevSalary = jelevCounter * budget / n;
            double royalSalary = royalCounter * budget / n;
            double roliSalary = roliCounter * budget / n;
            double trofonSalary = trofonCounter * budget / n;
            double sinoSalary = sinoCounter * budget / n;
            double guestsSalary = budget - jelevSalary - royalSalary - roliSalary - trofonSalary - sinoSalary;

            Console.WriteLine($"Jelev salary: {jelevSalary:f2} lv");
            Console.WriteLine($"RoYaL salary: {royalSalary:f2} lv");
            Console.WriteLine($"Roli salary: {roliSalary:f2} lv");
            Console.WriteLine($"Trofon salary: {trofonSalary:f2} lv");
            Console.WriteLine($"Sino salary: {sinoSalary:f2} lv");
            Console.WriteLine($"Others salary: {guestsSalary:f2} lv");
        }
    }
}
