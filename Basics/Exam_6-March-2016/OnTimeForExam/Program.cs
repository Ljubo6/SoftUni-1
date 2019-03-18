using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTimeForExam
{
    class Program
    {
        static void Main(string[] args)
        {
            int hhExam = int.Parse(Console.ReadLine());
            int mmExam = int.Parse(Console.ReadLine());
            int hhArrival = int.Parse(Console.ReadLine());
            int mmArrival = int.Parse(Console.ReadLine());

            int timeExam = hhExam * 60 + mmExam;
            int timeArrival = hhArrival * 60 + mmArrival;

            if (hhExam == 0 && mmExam == 0) { timeExam = 24 * 60; }

            if (timeExam < timeArrival)
            {
                Console.WriteLine("Late");
            }
            else if (timeArrival == timeExam || timeArrival >= timeExam - 30)
            {
                Console.WriteLine("On time");
            }
            else if (timeArrival < timeExam + 30)
            {
                Console.WriteLine("Early");
            }

            if (timeExam - timeArrival >= 1 && timeExam - timeArrival < 60)
            {
                Console.WriteLine(timeExam - timeArrival + " minutes before the start");
            }
            if (timeExam - timeArrival >= 60)
            {
                if ((timeExam - timeArrival) % 60 <= 9)
                {
                    Console.WriteLine(((timeExam - timeArrival) / 60) + ":0" +
                        ((timeExam - timeArrival) % 60) + " hours before the start");
                }
                else
                {
                    Console.WriteLine(((timeExam - timeArrival) / 60) + ":" +
                    ((timeExam - timeArrival) % 60) + " hours before the start");
                }
            }


            if (timeArrival - timeExam >= 1 && timeArrival - timeExam < 60)
            {
                Console.WriteLine(timeArrival - timeExam + " minutes after the start");
            }
            if (timeArrival - timeExam >= 60)
            {
                if ((timeArrival - timeExam) % 60 <= 9)
                {
                    Console.WriteLine(((timeArrival - timeExam) / 60) + ":0" +
                        ((timeArrival - timeExam) % 60) + " hours after the start");
                }
                else
                {
                    Console.WriteLine(((timeArrival - timeExam) / 60) + ":" +
                        ((timeArrival - timeExam) % 60) + " hours after the start");
                }
            }
        }
    }
}
